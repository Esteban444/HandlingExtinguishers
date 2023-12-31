﻿using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public HandlingExtinguisherContext databaseContext { get; set; }

        public BaseRepository(HandlingExtinguisherContext context)
        {
            databaseContext = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            var entitySet = databaseContext.Set<T>();
            return entitySet.AsQueryable();
        }
        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate)!;
        }

        public virtual Task<T> GetFirst(Expression<Func<T, bool>> predicate)
        {
            return GetAll().FirstOrDefaultAsync(predicate)!;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual IQueryable<T> FindByAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return GetAll().AsNoTracking().Where(predicate);
        }

        public async Task Add(T entity)
        {
            var UpdatedAt = entity.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) entity.GetType().GetProperty("UpdatedAt")!.SetValue(entity, DateTime.UtcNow);

            var CreatedAt = entity.GetType().GetProperty("CreatedAt");
            if (CreatedAt != null) entity.GetType().GetProperty("CreatedAt")!.SetValue(entity, DateTime.UtcNow);

            await databaseContext.AddAsync(entity);
            databaseContext.Entry(entity).State = EntityState.Added;
            await databaseContext.SaveChangesAsync();
        }

        public async Task AddRange(List<T> entity)
        {
            entity = entity.Select(x =>
            {
                if (x.GetType().GetProperty("UpdatedAt") != null) x.GetType().GetProperty("UpdatedAt")!.SetValue(x, DateTime.UtcNow);
                if (x.GetType().GetProperty("CreatedAt") != null) x.GetType().GetProperty("CreatedAt")!.SetValue(x, DateTime.UtcNow);
                return x;
            }).ToList();

            databaseContext.AddRange(entity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            databaseContext.Remove(entity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteRange(List<T> entity)
        {
            databaseContext.RemoveRange(entity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            var UpdatedAt = entity.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) entity.GetType().GetProperty("UpdatedAt")!.SetValue(entity, DateTime.UtcNow);

            databaseContext.Update(entity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateRange(List<T> entity)
        {
            entity = entity.Select(x =>
            {
                if (x.GetType().GetProperty("UpdatedAt") != null) x.GetType().GetProperty("UpdatedAt")!.SetValue(x, DateTime.UtcNow);
                return x;
            }).ToList();

            databaseContext.UpdateRange(entity);
            await databaseContext.SaveChangesAsync();
        }

        public Task<T> MapperUpdate(T fromDB, T fromRequest)
        {
            var typeOfSender = fromRequest.GetType();
            var typeOfReceiver = fromDB.GetType();
            foreach (var fieldOfReceiver in typeOfSender.GetFields())
            {
                var fieldOfB = typeOfReceiver.GetField(fieldOfReceiver.Name);
                fieldOfB!.SetValue(fromDB, fieldOfReceiver.GetValue(fromRequest));
            }
            foreach (var propertyOfReceiver in typeOfSender.GetProperties())
            {
                var propertyOfB = typeOfReceiver.GetProperty(propertyOfReceiver.Name);
                propertyOfB!.SetValue(fromDB, propertyOfReceiver.GetValue(fromRequest));
            }
            return Task.FromResult(fromDB);
        }

        public async Task Patch(T entity)
        {
            var entry = databaseContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                var key = entity.GetType().GetProperty("Id")!.GetValue(entity, null)!;
                var originalEntity = await databaseContext.Set<T>().FindAsync(key);

                entry = databaseContext.Entry(originalEntity!);
                entry.CurrentValues.SetValues(entity);
            }

            var updatedAtProperty = entity.GetType().GetProperty("UpdatedAt");
            if (updatedAtProperty != null)
            {
                updatedAtProperty.SetValue(entity, DateTime.UtcNow);
                entry.Property("UpdatedAt").IsModified = true;
            }

            var changedProperties = entry.Properties
                .Where(p => p.IsModified)
                .Select(p => p.Metadata.Name);

            foreach (var name in changedProperties)
            {
                entry.Property(name).IsModified = true;
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task PatchRange(List<T> entities)
        {
            foreach (var entity in entities)
            {
                var entry = databaseContext.Entry(entity);

                if (entry.State == EntityState.Detached)
                {
                    var key = entity.GetType().GetProperty("Id")!.GetValue(entity, null)!;
                    var originalEntity = await databaseContext.Set<T>().FindAsync(key);

                    entry = databaseContext.Entry(originalEntity!)!;
                    entry.CurrentValues.SetValues(entity);
                }

                var updatedAtProperty = entity.GetType().GetProperty("UpdatedAt");
                if (updatedAtProperty != null)
                {
                    updatedAtProperty.SetValue(entity, DateTime.UtcNow);
                    entry.Property("UpdatedAt").IsModified = true;
                }

                var changedProperties = entry.Properties
                    .Where(p => p.IsModified)
                    .Select(p => p.Metadata.Name);

                foreach (var name in changedProperties)
                {
                    entry.Property(name).IsModified = true;
                }
            }
            await databaseContext.SaveChangesAsync();
        }
    }
}

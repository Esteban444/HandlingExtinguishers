namespace HandlingExtinguishers.Infraestructure.Repositories;

#region Usings
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
#endregion

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly HandlingExtinguisherContext databaseContext;

    public BaseRepository( HandlingExtinguisherContext context )
    {
        databaseContext = context;
    }

    public virtual IQueryable<T> GetAll()
    {
        var entitySet = databaseContext.Set<T>();
        return entitySet.AsQueryable();
    }
    public virtual T GetSingle( Expression<Func<T, bool>> predicate )
    {
        return GetAll().FirstOrDefault( predicate )!;
    }

    public virtual Task<T> GetFirst( Expression<Func<T, bool>> predicate )
    {
        return GetAll().FirstOrDefaultAsync( predicate )!;
    }

    public virtual IQueryable<T> FindBy( Expression<Func<T, bool>> predicate )
    {
        return GetAll().Where( predicate );
    }

    public virtual IQueryable<T> FindByAsNoTracking( Expression<Func<T, bool>> predicate )
    {
        return GetAll().AsNoTracking().Where( predicate );
    }

    public async Task Add( T entity )
    {
        var UpdatedAt = entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt );
        if ( UpdatedAt is not null ) entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt )!.SetValue( entity, DateTime.UtcNow );

        var CreatedAt = entity.GetType().GetProperty( CommonConstants.PropertyCreatedAt );
        if ( CreatedAt is not null ) entity.GetType().GetProperty( CommonConstants.PropertyCreatedAt )!.SetValue( entity, DateTime.UtcNow );

        await databaseContext.AddAsync( entity );
        databaseContext.Entry( entity ).State = EntityState.Added;

        await databaseContext.SaveChangesAsync();
    }

    public async Task AddRange( List<T> entity )
    {
        entity = entity.Select( entity =>
        {
            if ( entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt ) is not null ) entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt )!.SetValue( entity, DateTime.UtcNow );
            if ( entity.GetType().GetProperty( CommonConstants.PropertyCreatedAt ) is not null ) entity.GetType().GetProperty( CommonConstants.PropertyCreatedAt )!.SetValue( entity, DateTime.UtcNow );

            return entity;

        }).ToList();

        databaseContext.AddRange( entity );

        await databaseContext.SaveChangesAsync();
    }

    public async Task Delete( T entity )
    {
        databaseContext.Remove( entity );

        await databaseContext.SaveChangesAsync();
    }

    public async Task DeleteRange( List<T> entity )
    {
        databaseContext.RemoveRange( entity );

        await databaseContext.SaveChangesAsync();
    }

    public async Task Update( T entity )
    {
        var UpdatedAt = entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt );
            if ( UpdatedAt is not null ) entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt )!.SetValue( entity, DateTime.UtcNow );

        databaseContext.Update( entity );

        await databaseContext.SaveChangesAsync();
    }

    public async Task UpdateRange( List<T> entity )
    {
        entity = entity.Select( entity =>
        {
            if ( entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt ) is not null ) entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt )!.SetValue( entity, DateTime.UtcNow );

            return entity;

        }).ToList();

        databaseContext.UpdateRange( entity );

        await databaseContext.SaveChangesAsync();
    }

        public Task<T> MapperUpdate( T fromDB, T fromRequest )
        {
            var sourceType = fromRequest.GetType();
            var targetType = fromDB.GetType();

            foreach ( var sourceField in sourceType.GetFields() )
            {
                var targetField = targetType.GetField( sourceField.Name );
                targetField!.SetValue( fromDB, sourceField.GetValue( fromRequest ) );
            }

            foreach ( var sourceProperty in sourceType.GetProperties() )
            {
                var targetProperty = targetType.GetProperty( sourceProperty.Name );
                targetProperty!.SetValue( fromDB, sourceProperty.GetValue( fromRequest ) );
            }

            return Task.FromResult( fromDB );
        }

    public async Task Patch( T entity )
    {
        var entry = databaseContext.Entry( entity );

        if ( entry.State == EntityState.Detached )
        {
            var key = entity.GetType().GetProperty( CommonConstants.PropertyId )!.GetValue( entity, null )!;
            var originalEntity = await databaseContext.Set<T>().FindAsync( key );

            entry = databaseContext.Entry( originalEntity! );
            entry.CurrentValues.SetValues( entity );
        }

            var updatedAtProperty = entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt );
        if ( updatedAtProperty != null )
        {
            updatedAtProperty.SetValue( entity, DateTime.UtcNow );
            entry.Property( CommonConstants.PropertyUpdatedAt ).IsModified = true;
        }

        var changedProperties = entry.Properties
            .Where( property => property.IsModified )
            .Select( property => property.Metadata.Name );

        foreach ( var propertyName in changedProperties )
        {
            entry.Property( propertyName ).IsModified = true;
        }

        await databaseContext.SaveChangesAsync();
    }

    public async Task PatchRange( List<T> entities )
    {
        foreach ( var entity in entities )
        {
            var entry = databaseContext.Entry( entity );

            if ( entry.State == EntityState.Detached )
            {
                var key = entity.GetType().GetProperty( CommonConstants.PropertyId )!.GetValue( entity, null )!;
                var originalEntity = await databaseContext.Set<T>().FindAsync( key );

                entry = databaseContext.Entry( originalEntity! );
                entry.CurrentValues.SetValues( entity );
            }

                var updatedAtProperty = entity.GetType().GetProperty( CommonConstants.PropertyUpdatedAt );
            if ( updatedAtProperty is not null )
            {
                updatedAtProperty.SetValue( entity, DateTime.UtcNow );
                entry.Property( CommonConstants.PropertyUpdatedAt ).IsModified = true;
            }

            var changedProperties = entry.Properties
                .Where( property => property.IsModified )
                .Select( property => property.Metadata.Name );

            foreach ( var propertyName in changedProperties )
            {
                entry.Property( propertyName ).IsModified = true;
            }
        }

        await databaseContext.SaveChangesAsync();
    }
}

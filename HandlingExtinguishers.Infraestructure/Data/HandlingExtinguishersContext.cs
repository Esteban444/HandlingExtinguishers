using HandlingExtinguishers.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HandlingExtinguisher.Infraestructure.Data
{
    public partial class HandlingExtinguisherContext : IdentityDbContext<Users>
    {
        public HandlingExtinguisherContext(DbContextOptions<HandlingExtinguisherContext> options) : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<CreditService> CreditService { get; set; }
        //public DbSet<DetalleExtintorClientes> DetaileFireExtinguisherClient { get; set; }
        //public DbSet<DetalleServicioDetalleClientes> DetailServiceDetailClient { get; set; }
        public DbSet<DetailService> DetailService { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<WeightExtinguisher> WeightExtinguisher { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<TypeExtinguisher> TypeExtinguisher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<Company>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nit");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

            });

            modelBuilder.Entity<CreditService>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<CreditService>().Property(e => e.IdService).HasConversion<string>();

            modelBuilder.Entity<DetailService>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<DetailService>().Property(e => e.IdService).HasConversion<string>();
            modelBuilder.Entity<DetailService>().Property(e => e.IdTypeExtinguisher).HasConversion<string>();
            modelBuilder.Entity<DetailService>().Property(e => e.IdWeightExtinguisher).HasConversion<string>();

            modelBuilder.Entity<Employee>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<Employee>().Property(e => e.CompanyId).HasConversion<string>();

            modelBuilder.Entity<Expense>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<Inventory>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<Inventory>().Property(e => e.IdProduct).HasConversion<string>();
            modelBuilder.Entity<Inventory>().Property(e => e.IdTypeExtinguisher).HasConversion<string>();
            modelBuilder.Entity<Inventory>().Property(e => e.IdWeigthExtinguisher).HasConversion<string>();

            modelBuilder.Entity<WeightExtinguisher>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<Price>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<Price>().Property(e => e.IdProduct).HasConversion<string>();

            modelBuilder.Entity<Product>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<Product>().Property(e => e.IdTypeExtinguisher).HasConversion<string>();
            modelBuilder.Entity<Product>().Property(e => e.IdWeightExtinguisher).HasConversion<string>();

            modelBuilder.Entity<Service>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<Service>().Property(e => e.IdClient).HasConversion<string>();
            modelBuilder.Entity<Service>().Property(e => e.IdEmployee).HasConversion<string>();

            modelBuilder.Entity<TypeExtinguisher>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}

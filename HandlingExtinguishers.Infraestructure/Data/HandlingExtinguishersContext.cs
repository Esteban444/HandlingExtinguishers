namespace HandlingExtinguishers.Infraestructure.Data;

#region Usings
using HandlingExtinguishers.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
#endregion

public partial class HandlingExtinguisherContext( DbContextOptions<HandlingExtinguisherContext> options ) : IdentityDbContext<Users>( options )
{
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
        modelBuilder.Entity<Client>().Property( entyty => entyty.Id ).HasConversion<string>();

        modelBuilder.Entity<Company>().Property( entyty => entyty.Id ).HasConversion<string>();
        modelBuilder.Entity<Company>( entity =>
        {
            entity.ToTable("Company");

            entity.HasKey(e => e.Id);

            entity.Property( entyty => entyty.Id ).HasColumnName( "id" );

            entity.Property( entyty => entyty.Address )
                .HasMaxLength( 100 )
                .IsUnicode( false )
                .HasColumnName( "address" );

            entity.Property( entyty => entyty.Email )
                .HasMaxLength( 150 )
                .IsUnicode( false )
                .HasColumnName( "email" );

            entity.Property( entyty => entyty.Nit )
                .HasMaxLength( 50 )
                .IsUnicode( false )
                .HasColumnName( "nit" );

            entity.Property( entyty => entyty.Name )
                .HasMaxLength( 250 )
                .IsUnicode( false )
                .HasColumnName( "name" );

            entity.Property( entyty => entyty.Phone )
                .HasMaxLength( 50 )
                .IsUnicode( false )
                .HasColumnName( "phone" );

        });

        modelBuilder.Entity<CreditService>().Property( entyty => entyty.Id ).HasConversion<string>();
        modelBuilder.Entity<CreditService>().Property( entyty => entyty.IdService ).HasConversion<string>();

        modelBuilder.Entity<DetailService>().Property( entyty => entyty.Id ).HasConversion<string>();
        modelBuilder.Entity<DetailService>().Property( entyty => entyty.IdService ).HasConversion<string>();
        modelBuilder.Entity<DetailService>().Property( entyty => entyty.IdTypeExtinguisher ).HasConversion<string>();
        modelBuilder.Entity<DetailService>().Property( entyty => entyty.IdWeightExtinguisher ).HasConversion<string>();

        modelBuilder.Entity<Employee>().Property( entyty => entyty.Id ).HasConversion<string>();
        modelBuilder.Entity<Employee>().Property( entyty => entyty.CompanyId ).HasConversion<string>();
        modelBuilder.Entity<Expense>().Property( entyty => entyty.Id ).HasConversion<string>();

        modelBuilder.Entity<Inventory>().Property( entyty => entyty.Id ).HasConversion<string>();
        modelBuilder.Entity<Inventory>().Property( entyty => entyty.IdProduct ).HasConversion<string>();
        modelBuilder.Entity<Inventory>().Property( entyty => entyty.IdTypeExtinguisher ).HasConversion<string>();
        modelBuilder.Entity<Inventory>().Property( entyty => entyty.IdWeigthExtinguisher ).HasConversion<string>();

        modelBuilder.Entity<WeightExtinguisher>().Property( entyty => entyty.Id ).HasConversion<string>();

        modelBuilder.Entity<Price>().Property( entyty => entyty.Id ).HasConversion<string>();
        modelBuilder.Entity<Price>().Property( entyty => entyty.IdProduct ).HasConversion<string>();

        modelBuilder.Entity<Product>().Property( entyty => entyty.Id ).HasConversion<string>();
        modelBuilder.Entity<Product>().Property( entyty => entyty.IdTypeExtinguisher ).HasConversion<string>();
        modelBuilder.Entity<Product>().Property( entyty => entyty.IdWeightExtinguisher ).HasConversion<string>();

        modelBuilder.Entity<Service>().Property( entyty => entyty.Id ).HasConversion<string>();
        modelBuilder.Entity<Service>().Property( entyty => entyty.IdClient ).HasConversion<string>();
        modelBuilder.Entity<Service>().Property( entyty => entyty.IdEmployee ).HasConversion<string>();

        modelBuilder.Entity<TypeExtinguisher>().Property( entyty => entyty.Id ).HasConversion<string>();

        modelBuilder.ApplyConfigurationsFromAssembly( Assembly.GetExecutingAssembly() );

        base.OnModelCreating( modelBuilder );
    }

}

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
    public DbSet<DetailExtinguisherClient> DetailExtinguisherClient { get; set; }
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

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.Entity<Client>().Property( entyty => entyty.ClientId ).HasConversion<string>();

        modelBuilder.Entity<Company>().Property( entyty => entyty.CompanyId ).HasConversion<string>();
        modelBuilder.Entity<Company>( entity =>
        {
            entity.ToTable("Company");

            entity.HasKey(e => e.CompanyId);

            entity.Property( entyty => entyty.CompanyId ).HasColumnName( "id" );

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

        modelBuilder.Entity<CreditService>().Property( entyty => entyty.CreditServiceId ).HasConversion<string>();
        modelBuilder.Entity<CreditService>().Property( entyty => entyty.ServiceId ).HasConversion<string>();

        modelBuilder.Entity<DetailService>().Property( entyty => entyty.DetailServiceId ).HasConversion<string>();
        modelBuilder.Entity<DetailService>().Property( entyty => entyty.ServiceId ).HasConversion<string>();
        modelBuilder.Entity<DetailService>().Property( entyty => entyty.TypeExtinguisherId ).HasConversion<string>();
        modelBuilder.Entity<DetailService>().Property( entyty => entyty.WeightExtinguisherId ).HasConversion<string>();

        modelBuilder.Entity<Employee>().Property( entyty => entyty.EmployeeId ).HasConversion<string>();
        modelBuilder.Entity<Employee>().Property( entyty => entyty.CompanyId ).HasConversion<string>();
        modelBuilder.Entity<Expense>().Property( entyty => entyty.ExpenseId ).HasConversion<string>(); 
        
        modelBuilder.Entity<Inventory>().Property( entyty => entyty.InventoryId ).HasConversion<string>();
        modelBuilder.Entity<Inventory>().Property( entyty => entyty.ProductId ).HasConversion<string>();
        modelBuilder.Entity<Inventory>().Property( entyty => entyty.TypeExtinguisherId ).HasConversion<string>();
        modelBuilder.Entity<Inventory>().Property( entyty => entyty.WeightExtinguisherId ).HasConversion<string>();

        modelBuilder.Entity<WeightExtinguisher>().Property( entyty => entyty.WeightExtinguisherId ).HasConversion<string>();

        modelBuilder.Entity<Price>().Property( entyty => entyty.PriceId ).HasConversion<string>();
        modelBuilder.Entity<Price>().Property( entyty => entyty.ProductId ).HasConversion<string>();

        modelBuilder.Entity<Product>().Property( entyty => entyty.ProductId ).HasConversion<string>();
        modelBuilder.Entity<Product>().Property( entyty => entyty.TypeExtinguisherId ).HasConversion<string>();
        modelBuilder.Entity<Product>().Property( entyty => entyty.WeightExtinguisherId ).HasConversion<string>();

        modelBuilder.Entity<Service>().Property( entyty => entyty.ServiceId ).HasConversion<string>();
        modelBuilder.Entity<Service>().Property( entyty => entyty.ClientId ).HasConversion<string>();
        modelBuilder.Entity<Service>().Property( entyty => entyty.EmployeeId ).HasConversion<string>();

        modelBuilder.Entity<TypeExtinguisher>().Property( entyty => entyty.TypeExtinguisherId ).HasConversion<string>();

        modelBuilder.ApplyConfigurationsFromAssembly( Assembly.GetExecutingAssembly() );

        base.OnModelCreating( modelBuilder );
    }

}

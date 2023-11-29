using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandlingExtinguishers.Infraestructure.Data.Configuration
{
    class ConfigurationInventory : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.DetailServiceId);

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.ExpirationDate).HasColumnType("datetime");



            /*builder.HasOne(d => d.WeightExtinguisher)
                .WithMany(p => p.Inventory)
                .HasForeignKey(d => d.IdWeigthExtinguisher)
                .HasConstraintName("");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("");

            builder.HasOne(d => d.TypeExtinguisher)
                .WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IdTypeExtinguisher)
                .HasConstraintName("");*/
        }
    }
}

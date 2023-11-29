using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandlingExtinguisher.Infraestructure.Data.Configuration
{
    public class ConfiguractionPrices : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Price");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");

            builder.Property(e => e.Iva)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("iva");

            builder.Property(e => e.price)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("price");

            /*builder.HasOne(d => d.DetailService)
                .WithMany(p => p.Prices)
                .HasForeignKey(d => d.IdDetailService)
                .HasConstraintName();

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Prices)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("");*/
        }
    }
}

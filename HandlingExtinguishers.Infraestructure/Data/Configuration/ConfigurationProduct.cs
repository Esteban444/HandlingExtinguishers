using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandlingExtinguisher.Infraestructure.Data.Configuration
{
    public class ConfigurationProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.TypeProduct)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("typeProduct");

            /*builder.HasOne(d => d.WeightExtinguisher)
                .WithMany(p => p.Product)
                .HasForeignKey(d => d.IdWeightExtinguisher)
                .HasConstraintName("");*/
        }
    }
}

using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandlingExtinguisher.Infraestructure.Data.Configuration
{
    public class ConfigurationDetailService : IEntityTypeConfiguration<DetailService>
    {
        public void Configure(EntityTypeBuilder<DetailService> builder)
        {
            builder.ToTable("DetailService");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Total).HasColumnType("decimal(18, 4)");

            builder.Property(e => e.Price).HasColumnType("decimal(18, 4)");

            /*builder.HasOne(d => d.WeightExtinguisher)
                 .WithMany(p => p.DetaileService)
                 .HasForeignKey(d => d.IdWeightExtinguisher)
                 .HasConstraintName("");

             builder.HasOne(d => d.Service)
                 .WithMany(p => p.DetailServices)
                 .HasForeignKey(d => d.IdService)
                 .HasConstraintName("");

             builder.HasOne(d => d.TypeExtinguisher)
                 .WithMany(p => p.DetailServices)
                 .HasForeignKey(d => d.IdTypeExtinguisher)
                 .HasConstraintName("");*/
        }
    }
}

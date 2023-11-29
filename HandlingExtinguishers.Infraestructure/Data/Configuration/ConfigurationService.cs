using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandlingExtinguisher.Infraestructure.Data.Configuration
{
    class ConfigurationService : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Servicios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.StateService)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.ServiceDate).HasColumnType("datetime");

            builder.Property(e => e.Price).HasColumnType("decimal(18, 4)");

            builder.Property(e => e.Advance).HasColumnType("decimal(18, 4)");

            /* builder.HasOne(d => d.Client)
                 .WithMany(p => p.Services)
                 .HasForeignKey(d => d.IdClient)
                 .HasConstraintName("");

             builder.HasOne(d => d.Employee)
                 .WithMany(p => p.Services)
                 .HasForeignKey(d => d.IdEmployee)
                 .HasConstraintName("");*/

        }
    }
}

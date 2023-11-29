using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HandlingExtinguishers.Infraestructure.Data.Configuration
{
    public class ConfigurationDetailExtinguisherClient : IEntityTypeConfiguration<DetailExtinguisherClient>
    {
        public void Configure(EntityTypeBuilder<DetailExtinguisherClient> builder)
        {
            builder.ToTable("DetailExtinguisherClient");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            //builder.Property(e => e.Quantity.HasColumnName("quantity");

            builder.Property(e => e.MaintenanceDate)
                .HasColumnType("datetime")
                .HasColumnName("MaintenanceDate");

            builder.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("ExpirationDate");

            builder.Property(e => e.IdClients).HasColumnName("idClients");

            builder.Property(e => e.WeightExtinguisher)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WeightExtinguisher");

            builder.Property(e => e.TypeExtinguisher)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TypeExtinguisher");

            /*builder.HasOne(d => d.Clientes)
                .WithMany(p => p.DetalleExtClientes)
                .HasForeignKey(d => d.IdClients)
                .HasConstraintName("");*/
        }
    }
}

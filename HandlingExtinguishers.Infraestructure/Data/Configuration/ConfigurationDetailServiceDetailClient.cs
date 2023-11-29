using HandlingEstinguisherS.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandlingExtinguisher.Infrastructure.Data.Configuration
{
    public class ConfigurationDetailServiceDetailClient : IEntityTypeConfiguration<DetailServiceDetailClient>
    {
        public void Configure(EntityTypeBuilder<DetailServiceDetailClient> builder)
        {
            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Id).HasColumnName("Id");

            /*builder.HasOne(d => d.DetalleExtintorCliente)
                .WithMany(p => p.DetalleServicioDetalleClientes)
                .HasForeignKey(d => d.IdDetalleExtintorCliente)
                .HasConstraintName("FK_DetalleServicioDetalleClientes_DetalleExtintorClientes");*/
        }
    }
}

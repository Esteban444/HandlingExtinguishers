using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HandlingExtinguisher.Infraestructure.Data.Configuration
{
    public class ConfigurationCreditService : IEntityTypeConfiguration<CreditService>
    {
        public void Configure(EntityTypeBuilder<CreditService> builder)
        {
            builder.ToTable("CreditService");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Advances)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("advances");

            builder.Property(e => e.Debt)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("debt");

            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");

            builder.Property(e => e.IdService).HasColumnName("idServicio");

            /*builder.HasOne(d => d.Service)
                .WithMany(p => p.CreditServices)
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("");*/
        }
    }
}

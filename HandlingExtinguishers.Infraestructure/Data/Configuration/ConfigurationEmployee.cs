using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandlingExtinguisher.Infraestructure.Data.Configuration
{
    class ConfigurationEmployee : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);

            /*builder.HasOne(d => d.Company)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("");*/
        }
    }
}

using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandlingExtinguisher.Infraestructure.Data.Configuration
{
    public class ConfigurationTypeEntinguisher : IEntityTypeConfiguration<TypeExtinguisher>
    {
        public void Configure(EntityTypeBuilder<TypeExtinguisher> builder)
        {
            builder.ToTable("TypeExtinguisher");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.TYpeExtinguisher)
                .HasColumnName("TypeExtinguisher")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}

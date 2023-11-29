using HandlingExtinguishers.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandlingExtinguisher.Infraestructure.Data.Configuration
{
    public class ConfigurationWeigthExtinguisher : IEntityTypeConfiguration<WeightExtinguisher>
    {
        public void Configure(EntityTypeBuilder<WeightExtinguisher> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}

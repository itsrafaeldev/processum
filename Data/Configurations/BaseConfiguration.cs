using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class BaseConfiguration : IEntityTypeConfiguration<Cache>
{
    public void Configure(EntityTypeBuilder<Cache> entity)
    {
        
    }
}
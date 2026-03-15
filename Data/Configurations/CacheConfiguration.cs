using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class CacheConfiguration : IEntityTypeConfiguration<Cache>
{
    public void Configure(EntityTypeBuilder<Cache> entity)
    {
        entity.HasKey(e => e.Key)
              .HasName("cache_pkey");

        entity.ToTable("cache");

        entity.Property(e => e.Key)
            .HasMaxLength(255)
            .HasColumnName("key");

        entity.Property(e => e.Expiration)
            .HasColumnName("expiration");

        entity.Property(e => e.Value)
            .HasColumnName("value");
    }
}
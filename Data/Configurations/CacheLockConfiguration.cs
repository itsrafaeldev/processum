using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class CacheLockConfiguration : IEntityTypeConfiguration<CacheLock>
{
    public void Configure(EntityTypeBuilder<CacheLock> entity)
    {
        entity.HasKey(e => e.Key)
              .HasName("cache_locks_pkey");

        entity.ToTable("cache_locks");

        entity.Property(e => e.Key)
            .HasMaxLength(255)
            .HasColumnName("key");

        entity.Property(e => e.Expiration)
            .HasColumnName("expiration");

        entity.Property(e => e.Owner)
            .HasMaxLength(255)
            .HasColumnName("owner");
    }
}
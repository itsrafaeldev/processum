using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class MigrationConfiguration : IEntityTypeConfiguration<Migration>
{
    public void Configure(EntityTypeBuilder<Migration> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("migrations_pkey");

        entity.ToTable("migrations");

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.Batch)
            .HasColumnName("batch");

        entity.Property(e => e.Migration1)
            .HasMaxLength(255)
            .HasColumnName("migration");
    }
}
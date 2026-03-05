using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class EntityConfiguration : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("entities_pkey");

        entity.ToTable("entities");

        entity.HasIndex(e => e.IdPublic)
              .IsUnique()
              .HasDatabaseName("entities_id_public_key");

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.EntityType)
            .HasMaxLength(2)
            .IsFixedLength()
            .HasColumnName("entity_type");

        entity.Property(e => e.IdPublic)
            .HasColumnName("id_public");

        entity.Property(e => e.StatusId)
            .HasColumnName("status_id");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");
    }
}
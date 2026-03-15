using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class EntitiesRolesMapConfiguration : IEntityTypeConfiguration<EntitiesRolesMap>
{
    public void Configure(EntityTypeBuilder<EntitiesRolesMap> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("entities_roles_map_pkey");

        entity.ToTable("entities_roles_map");

        entity.HasIndex(e => new { e.EntityId, e.RoleId })
              .IsUnique()
              .HasDatabaseName("unique_entity_role");

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.AssignedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("assigned_at");

        entity.Property(e => e.AssignedBy)
            .HasColumnName("assigned_by");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.EntityId)
            .HasColumnName("entity_id");

        entity.Property(e => e.Notes)
            .HasColumnName("notes");

        entity.Property(e => e.RoleId)
            .HasColumnName("role_id");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.Role)
            .WithMany(p => p.EntitiesRolesMaps)
            .HasForeignKey(d => d.RoleId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_entities_roles_map");
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class EntitiesRoleConfiguration : IEntityTypeConfiguration<EntitiesRole>
{
    public void Configure(EntityTypeBuilder<EntitiesRole> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("entities_roles_pkey");

        entity.ToTable("entities_roles");

        entity.HasIndex(e => e.Name)
              .HasDatabaseName("entities_roles_name_key")
              .IsUnique();

        entity.Property(e => e.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.Description)
            .HasMaxLength(255)
            .HasColumnName("description");

        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");
    }
}
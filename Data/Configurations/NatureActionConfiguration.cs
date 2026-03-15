using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class NatureActionConfiguration : IEntityTypeConfiguration<NatureAction>
{
    public void Configure(EntityTypeBuilder<NatureAction> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("nature_actions_pkey");

        entity.ToTable("nature_actions");

        entity.Property(e => e.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.Nature)
            .HasMaxLength(50)
            .HasColumnName("nature");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");
    }
}
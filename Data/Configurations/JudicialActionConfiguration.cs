using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class JudicialActionConfiguration : IEntityTypeConfiguration<JudicialAction>
{
    public void Configure(EntityTypeBuilder<JudicialAction> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("judicials_actions_pkey");

        entity.ToTable("judicials_actions");

        entity.Property(e => e.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.Action)
            .HasMaxLength(150)
            .HasColumnName("judicial_action");

        entity.Property(e => e.NatureActionId)
            .HasColumnName("nature_action_id");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.NatureAction)
            .WithMany(p => p.JudicialAction)
            .HasForeignKey(d => d.NatureActionId)
            .HasConstraintName("fk_nature_action");
    }
}
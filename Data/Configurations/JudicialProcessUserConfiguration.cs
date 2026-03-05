using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class JudicialProcessUserConfiguration : IEntityTypeConfiguration<JudicialProcessUser>
{
    public void Configure(EntityTypeBuilder<JudicialProcessUser> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("judicial_process_user_pkey");

        entity.ToTable("judicial_process_user");

        entity.HasIndex(e => new { e.JudicialProcessId, e.UserId })
              .IsUnique()
              .HasDatabaseName("unique_process_user");

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.AccessLevel)
            .HasMaxLength(50)
            .HasDefaultValueSql("'private'::character varying")
            .HasColumnName("access_level");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.JudicialProcessId)
            .HasColumnName("judicial_process_id");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.Property(e => e.UserId)
            .HasColumnName("user_id");

        entity.HasOne(d => d.User)
            .WithMany(p => p.JudicialProcessUsers)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("fk_user");
    }
}
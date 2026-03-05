using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class JudicialProcessConfiguration : IEntityTypeConfiguration<JudicialProcess>
{
    public void Configure(EntityTypeBuilder<JudicialProcess> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("judicial_processes_pkey");

        entity.ToTable("judicial_processes");

        entity.HasIndex(e => e.IdPublic)
              .IsUnique()
              .HasDatabaseName("judicial_processes_id_public_key");

        entity.HasIndex(e => e.ProcessNumber)
              .IsUnique()
              .HasDatabaseName("unique_process_number");

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

        entity.Property(e => e.IdPublic)
            .HasColumnName("id_public");

        entity.Property(e => e.InitialDate)
            .HasColumnName("initial_date");

        entity.Property(e => e.IsArchived)
            .HasDefaultValue(false)
            .HasColumnName("is_archived");

        entity.Property(e => e.JudicialActionId)
            .HasColumnName("judicial_action_id");

        entity.Property(e => e.NatureActionId)
            .HasColumnName("nature_action_id");

        entity.Property(e => e.ProcessNumber)
            .HasMaxLength(20)
            .HasColumnName("process_number");

        entity.Property(e => e.Respondent)
            .HasMaxLength(255)
            .HasColumnName("respondent");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.Property(e => e.UserId)
            .HasColumnName("user_id");

        entity.HasOne(d => d.NatureAction)
            .WithMany(p => p.JudicialProcesses)
            .HasForeignKey(d => d.NatureActionId)
            .HasConstraintName("fk_nature_action");

        // entity.HasOne(d => d.User)
        //     .WithMany(p => p.JudicialProcesses)
        //     .HasForeignKey(d => d.UserId)
        //     .HasConstraintName("fk_user_id");
    }
}
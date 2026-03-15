using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("sessions_pkey");

        entity.ToTable("sessions");

        entity.HasIndex(e => e.LastActivity)
              .HasDatabaseName("sessions_last_activity_index");

        entity.HasIndex(e => e.UserId)
              .HasDatabaseName("sessions_user_id_index");

        entity.Property(e => e.Id)
            .HasMaxLength(255)
            .HasColumnName("id");

        entity.Property(e => e.IpAddress)
            .HasMaxLength(45)
            .HasColumnName("ip_address");

        entity.Property(e => e.LastActivity)
            .HasColumnName("last_activity");

        entity.Property(e => e.Payload)
            .HasColumnName("payload");

        entity.Property(e => e.UserAgent)
            .HasColumnName("user_agent");

        entity.Property(e => e.UserId)
            .HasColumnName("user_id");
    }
}
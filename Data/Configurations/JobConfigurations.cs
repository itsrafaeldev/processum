using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("jobs_pkey");

        entity.ToTable("jobs");

        entity.HasIndex(e => e.Queue)
              .HasDatabaseName("jobs_queue_index");

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.Attempts)
            .HasColumnName("attempts");

        entity.Property(e => e.AvailableAt)
            .HasColumnName("available_at");

        entity.Property(e => e.CreatedAt)
            .HasColumnName("created_at");

        entity.Property(e => e.Payload)
            .HasColumnName("payload");

        entity.Property(e => e.Queue)
            .HasMaxLength(255)
            .HasColumnName("queue");

        entity.Property(e => e.ReservedAt)
            .HasColumnName("reserved_at");
    }
}
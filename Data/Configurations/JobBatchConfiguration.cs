using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class JobBatchConfiguration : IEntityTypeConfiguration<JobBatch>
{
    public void Configure(EntityTypeBuilder<JobBatch> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("job_batches_pkey");

        entity.ToTable("job_batches");

        entity.Property(e => e.Id)
            .HasMaxLength(255)
            .HasColumnName("id");

        entity.Property(e => e.CancelledAt)
            .HasColumnName("cancelled_at");

        entity.Property(e => e.CreatedAt)
            .HasColumnName("created_at");

        entity.Property(e => e.FailedJobIds)
            .HasColumnName("failed_job_ids");

        entity.Property(e => e.FailedJobs)
            .HasColumnName("failed_jobs");

        entity.Property(e => e.FinishedAt)
            .HasColumnName("finished_at");

        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("name");

        entity.Property(e => e.Options)
            .HasColumnName("options");

        entity.Property(e => e.PendingJobs)
            .HasColumnName("pending_jobs");

        entity.Property(e => e.TotalJobs)
            .HasColumnName("total_jobs");
    }
}
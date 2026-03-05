// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using OctaPro.Models;

// namespace OctaPro.Data.Configurations;

// public class FailedJobConfiguration : IEntityTypeConfiguration<FailedJob>
// {
//     public void Configure(EntityTypeBuilder<FailedJob> entity)
//     {
//         entity.HasKey(e => e.Id)
//               .HasName("failed_jobs_pkey");

//         entity.ToTable("failed_jobs");

//         entity.HasIndex(e => e.Uuid)
//               .IsUnique()
//               .HasDatabaseName("failed_jobs_uuid_unique");

//         entity.Property(e => e.Id)
//             .HasColumnName("id");

//         entity.Property(e => e.Connection)
//             .HasColumnName("connection");

//         entity.Property(e => e.Exception)
//             .HasColumnName("exception");

//         entity.Property(e => e.FailedAt)
//             .HasDefaultValueSql("CURRENT_TIMESTAMP")
//             .HasColumnType("timestamp(0) without time zone")
//             .HasColumnName("failed_at");

//         entity.Property(e => e.Payload)
//             .HasColumnName("payload");

//         entity.Property(e => e.Queue)
//             .HasColumnName("queue");

//         entity.Property(e => e.Uuid)
//             .HasMaxLength(255)
//             .HasColumnName("uuid");
//     }
// }
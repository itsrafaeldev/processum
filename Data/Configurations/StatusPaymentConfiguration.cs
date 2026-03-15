using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class StatusPaymentConfiguration : IEntityTypeConfiguration<StatusPayment>
{
    public void Configure(EntityTypeBuilder<StatusPayment> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("status_payment_pkey");

        entity.ToTable("status_payment");

        entity.Property(e => e.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.Description)
            .HasMaxLength(30)
            .HasColumnName("description");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");
    }
}
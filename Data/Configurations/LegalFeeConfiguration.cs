using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class LegalFeeConfiguration : IEntityTypeConfiguration<LegalFee>
{
    public void Configure(EntityTypeBuilder<LegalFee> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("legal_fees_pkey");

        entity.ToTable("legal_fees");

        entity.HasIndex(e => e.IdPublic)
              .IsUnique()
              .HasDatabaseName("legal_fees_id_public_key");

        entity.Property(e => e.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");

        entity.Property(e => e.Amount)
            .HasPrecision(10, 2)
            .HasDefaultValue(0.0m)
            .HasColumnName("amount");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.IdPublic)
            .HasColumnName("id_public");

        entity.Property(e => e.JudicialProcessId)
            .HasColumnName("judicial_process_id");

        entity.Property(e => e.Note)
            .HasMaxLength(255)
            .HasColumnName("note");

        entity.Property(e => e.QuantityInstallment)
            .HasColumnName("quantity_installment")
            .HasDefaultValue(1);

        entity.Property(e => e.StatusPaymentId)
            .HasColumnName("status_payment_id");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.Property(e => e.UserId)
            .HasColumnName("user_id");

        entity.HasOne(d => d.JudicialProcess)
            .WithMany(p => p.LegalFees)
            .HasForeignKey(d => d.JudicialProcessId)
            .HasConstraintName("fk_judicial_process");

        entity.HasOne(d => d.StatusPayment)
            .WithMany(p => p.LegalFees)
            .HasForeignKey(d => d.StatusPaymentId)
            .HasConstraintName("fk_status_payment");

        entity.HasOne(d => d.User)
            .WithMany(p => p.LegalFees)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("fk_user_id");
    }
}
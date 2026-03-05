using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class LegalFeesInstallmentConfiguration : IEntityTypeConfiguration<LegalFeesInstallment>
{
    public void Configure(EntityTypeBuilder<LegalFeesInstallment> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("installments_legal_fees_pkey");

        entity.ToTable("legal_fees_installments");

        entity.HasIndex(e => e.IdPublic)
              .IsUnique()
              .HasDatabaseName("installments_legal_fees_id_public_key");

        entity.Property(e => e.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.CurrentInstallment)
            .HasColumnName("current_installment");

        entity.Property(e => e.DueDate)
            .HasColumnName("due_date");

        entity.Property(e => e.EntityId)
            .IsRequired()
            .HasColumnName("entity_id");

        entity.Property(e => e.IdPublic)
            .HasColumnName("id_public");

        entity.Property(e => e.LegalFeeId)
            .HasColumnName("legal_fee_id");

        entity.Property(e => e.Note)
            .HasMaxLength(255)
            .HasColumnName("note");

        entity.Property(e => e.PaymentDate)
            .HasColumnName("payment_date");

        entity.Property(e => e.StatusPaymentId)
            .HasColumnName("status_payment_id");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.Property(e => e.ValueInstallment)
            .HasColumnName("value_installment");

        entity.HasOne(d => d.Entity)
            .WithMany(p => p.LegalFeesInstallments)
            .HasForeignKey(d => d.EntityId)
            .HasConstraintName("fk_legal_fee_entity");

        entity.HasOne(d => d.StatusPayment)
            .WithMany(p => p.LegalFeesInstallments)
            .HasForeignKey(d => d.StatusPaymentId)
            .HasConstraintName("fk_status_payment");
    }
}
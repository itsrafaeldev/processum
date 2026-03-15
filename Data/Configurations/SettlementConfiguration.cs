using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class SettlementConfiguration : IEntityTypeConfiguration<Settlement>
{
    public void Configure(EntityTypeBuilder<Settlement> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("installments_settlement_pkey");

        entity.ToTable("settlement");

        entity.HasIndex(e => e.IdPublic)
              .IsUnique()
              .HasDatabaseName("settlement_id_public_key");

        entity.Property(e => e.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");

        entity.Property(e => e.Amount)
            .HasPrecision(10, 2)
            .HasColumnName("amount");

        entity.Property(e => e.Competence)
            .HasMaxLength(7)
            .HasColumnName("competence");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.CurrentInstallment)
            .HasColumnName("current_installment");

        entity.Property(e => e.DueDate)
            .HasColumnName("due_date");

        entity.Property(e => e.IdPublic)
            .HasColumnName("id_public");

        entity.Property(e => e.JudicialProcessId)
            .HasColumnName("judicial_process_id");

        entity.Property(e => e.Note)
            .HasMaxLength(255)
            .HasColumnName("note");

        entity.Property(e => e.PaymentDate)
            .HasColumnName("payment_date");

        entity.Property(e => e.QuantityInstallment)
            .HasColumnName("quantity_installment");

        entity.Property(e => e.StatusPaymentId)
            .HasColumnName("status_payment_id");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.Property(e => e.UserId)
            .HasColumnName("user_id");

        entity.Property(e => e.ValueInstallment)
            .HasPrecision(10, 2)
            .HasComputedColumnSql(
                "(amount / (NULLIF(quantity_installment, 0))::numeric)",
                stored: true)
            .HasColumnName("value_installment");

        entity.HasOne(d => d.JudicialProcess)
            .WithMany(p => p.Settlements)
            .HasForeignKey(d => d.JudicialProcessId)
            .HasConstraintName("fk_judicial_process");

        entity.HasOne(d => d.StatusPayment)
            .WithMany(p => p.Settlements)
            .HasForeignKey(d => d.StatusPaymentId)
            .HasConstraintName("fk_status_payment");

        entity.HasOne(d => d.User)
            .WithMany(p => p.Settlements)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("fk_user_id");
    }
}
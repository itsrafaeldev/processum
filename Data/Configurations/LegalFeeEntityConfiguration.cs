using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class LegalFeeEntityConfiguration : IEntityTypeConfiguration<LegalFeeEntity>
{
    public void Configure(EntityTypeBuilder<LegalFeeEntity> entity)
    {
        entity.ToTable("legal_fee_entity");

        entity.HasKey(e => new { e.LegalFeeId, e.EntityId });

        entity.Property(e => e.LegalFeeId)
            .HasColumnName("legal_fee_id");

        entity.Property(e => e.EntityId)
            .HasColumnName("entity_id");

        entity.HasOne(e => e.Entity)
            .WithMany(e => e.LegalFeeEntities)
            .HasForeignKey(e => e.EntityId)
            .HasConstraintName("fk_legal_fee_entity_entity");

        entity.HasOne(e => e.LegalFee)
            .WithMany(lf => lf.LegalFeeEntities)
            .HasForeignKey(e => e.LegalFeeId)
            .HasConstraintName("fk_legal_fee_entity_legal_fee");
    }
}
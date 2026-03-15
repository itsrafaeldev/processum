using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class EntityCompanyConfiguration : IEntityTypeConfiguration<EntityCompany>
{
    public void Configure(EntityTypeBuilder<EntityCompany> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("entities_company_pkey");

        entity.ToTable("entities_company");

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.Cnpj)
            .HasMaxLength(20)
            .HasColumnName("cnpj");

        entity.Property(e => e.CorporateName)
            .HasMaxLength(200)
            .HasColumnName("corporate_name");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.CorporateEmail)
            .HasMaxLength(255)
            .HasColumnName("email");

        entity.Property(e => e.EntityId)
            .HasColumnName("entity_id");

        entity.Property(e => e.CorporateMobile)
            .HasMaxLength(50)
            .HasColumnName("mobile");

        entity.Property(e => e.CorporatePhone)
            .HasMaxLength(50)
            .HasColumnName("phone");

        entity.Property(e => e.TradeName)
            .HasMaxLength(200)
            .HasColumnName("trade_name");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.Entity)
            .WithOne(p => p.EntityCompany)
            .HasForeignKey<EntityCompany>(d => d.EntityId)
            .HasConstraintName("fk_entity_company");
    }
}
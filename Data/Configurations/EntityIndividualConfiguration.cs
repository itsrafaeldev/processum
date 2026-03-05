using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class EntityIndividualConfiguration : IEntityTypeConfiguration<EntityIndividual>
{
    public void Configure(EntityTypeBuilder<EntityIndividual> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("entities_individual_pkey");

        entity.ToTable("entities_individual");

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.Address)
            .HasMaxLength(255)
            .HasColumnName("address");

        entity.Property(e => e.BirthDate)
            .HasColumnName("birth_date");

        entity.Property(e => e.Cpf)
            .HasMaxLength(14)
            .HasColumnName("cpf");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.Email)
            .HasMaxLength(255)
            .HasColumnName("email");

        entity.Property(e => e.EntityId)
            .HasColumnName("entity_id");

        entity.Property(e => e.Mobile)
            .HasMaxLength(50)
            .HasColumnName("mobile");

        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("name");

        entity.Property(e => e.Phone)
            .HasMaxLength(50)
            .HasColumnName("phone");

        entity.Property(e => e.Rg)
            .HasMaxLength(20)
            .HasColumnName("rg");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.Entity)
            .WithOne(p => p.EntityIndividual)
            .HasForeignKey<EntityIndividual>(d => d.EntityId)
            .HasConstraintName("fk_entity_individual");
    }
}
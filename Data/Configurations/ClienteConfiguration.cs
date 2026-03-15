using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("clients_pkey");

        entity.ToTable("clients");

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.EntityId)
            .HasColumnName("entity_id");

        entity.Property(e => e.LawyerId)
            .HasColumnName("lawyer_id");

        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.Lawyer)
            .WithMany(p => p.Clients)
            .HasForeignKey(d => d.LawyerId)
            .HasConstraintName("fk_client_lawyer");
    }
}
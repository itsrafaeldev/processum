using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OctaPro.Models;

namespace OctaPro.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(e => e.Id)
              .HasName("users_pkey");

        entity.ToTable("users");

        entity.HasIndex(e => e.Email)
              .IsUnique()
              .HasDatabaseName("users_email_unique");

        entity.HasIndex(e => e.IdPublic)
              .IsUnique()
              .HasDatabaseName("users_id_public_key");

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.CreatedAt)
            .HasColumnType("timestamp(0) without time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.Email)
            .HasMaxLength(255)
            .HasColumnName("email");    

        entity.Property(e => e.IdPublic)
            .HasColumnName("id_public");

        entity.Property(e => e.ProfilePhotoPath)
            .HasMaxLength(2048)
            .HasColumnName("profile_photo_path");


        entity.Property(e => e.UpdatedAt)
            .HasColumnType("timestamp(0) without time zone")
            .HasColumnName("updated_at");

       
    }
}
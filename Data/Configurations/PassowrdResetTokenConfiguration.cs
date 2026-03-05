// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using OctaPro.Models;

// namespace OctaPro.Data.Configurations;

// public class PasswordResetTokenConfiguration : IEntityTypeConfiguration<PasswordResetToken>
// {
//     public void Configure(EntityTypeBuilder<PasswordResetToken> entity)
//     {
//         entity.HasKey(e => e.Email)
//               .HasName("password_reset_tokens_pkey");

//         entity.ToTable("password_reset_tokens");

//         entity.Property(e => e.Email)
//             .HasMaxLength(255)
//             .HasColumnName("email");

//         entity.Property(e => e.CreatedAt)
//             .HasColumnType("timestamp(0) without time zone")
//             .HasColumnName("created_at");

//         entity.Property(e => e.Token)
//             .HasMaxLength(255)
//             .HasColumnName("token");
//     }
// }
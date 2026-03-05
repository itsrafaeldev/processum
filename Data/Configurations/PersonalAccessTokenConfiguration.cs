// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using OctaPro.Models;

// namespace OctaPro.Data.Configurations;

// public class PersonalAccessTokenConfiguration : IEntityTypeConfiguration<PersonalAccessToken>
// {
//     public void Configure(EntityTypeBuilder<PersonalAccessToken> entity)
//     {
//         entity.HasKey(e => e.Id)
//               .HasName("personal_access_tokens_pkey");

//         entity.ToTable("personal_access_tokens");

//         entity.HasIndex(e => e.ExpiresAt)
//               .HasDatabaseName("personal_access_tokens_expires_at_index");

//         entity.HasIndex(e => e.Token)
//               .IsUnique()
//               .HasDatabaseName("personal_access_tokens_token_unique");

//         entity.HasIndex(e => new { e.TokenableType, e.TokenableId })
//               .HasDatabaseName("personal_access_tokens_tokenable_type_tokenable_id_index");

//         entity.Property(e => e.Id)
//             .HasColumnName("id");

//         entity.Property(e => e.Abilities)
//             .HasColumnName("abilities");

//         entity.Property(e => e.CreatedAt)
//             .HasColumnType("timestamp(0) without time zone")
//             .HasColumnName("created_at");

//         entity.Property(e => e.ExpiresAt)
//             .HasColumnType("timestamp(0) without time zone")
//             .HasColumnName("expires_at");

//         entity.Property(e => e.LastUsedAt)
//             .HasColumnType("timestamp(0) without time zone")
//             .HasColumnName("last_used_at");

//         entity.Property(e => e.Name)
//             .HasColumnName("name");

//         entity.Property(e => e.Token)
//             .HasMaxLength(64)
//             .HasColumnName("token");

//         entity.Property(e => e.TokenableId)
//             .HasColumnName("tokenable_id");

//         entity.Property(e => e.TokenableType)
//             .HasMaxLength(255)
//             .HasColumnName("tokenable_type");

//         entity.Property(e => e.UpdatedAt)
//             .HasColumnType("timestamp(0) without time zone")
//             .HasColumnName("updated_at");
//     }
// }
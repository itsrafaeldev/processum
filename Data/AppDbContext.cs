using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using processum.Models;

namespace processum.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cache> Caches { get; set; }

    public virtual DbSet<CacheLock> CacheLocks { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<EntityCompany> EntitiesCompanies { get; set; }

    public virtual DbSet<EntityIndividual> EntitiesIndividuals { get; set; }

    public virtual DbSet<EntitiesRole> EntitiesRoles { get; set; }

    public virtual DbSet<EntitiesRolesMap> EntitiesRolesMaps { get; set; }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobBatch> JobBatches { get; set; }

    public virtual DbSet<JudicialProcess> JudicialProcesses { get; set; }

    public virtual DbSet<JudicialProcessUser> JudicialProcessUsers { get; set; }

    public virtual DbSet<JudicialAction> JudicialActions { get; set; }

    public virtual DbSet<LegalFee> LegalFees { get; set; }

    public virtual DbSet<LegalFeesInstallment> LegalFeesInstallments { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<NatureAction> NatureActions { get; set; }

    public virtual DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

    public virtual DbSet<PersonalAccessToken> PersonalAccessTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Settlement> Settlements { get; set; }

    public virtual DbSet<StatusEntity> StatusEntities { get; set; }

    public virtual DbSet<StatusPayment> StatusPayments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cache>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("cache_pkey");

            entity.ToTable("cache");

            entity.Property(e => e.Key)
                .HasMaxLength(255)
                .HasColumnName("key");
            entity.Property(e => e.Expiration).HasColumnName("expiration");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<CacheLock>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("cache_locks_pkey");

            entity.ToTable("cache_locks");

            entity.Property(e => e.Key)
                .HasMaxLength(255)
                .HasColumnName("key");
            entity.Property(e => e.Expiration).HasColumnName("expiration");
            entity.Property(e => e.Owner)
                .HasMaxLength(255)
                .HasColumnName("owner");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EntityId)
                .HasColumnName("entity_id");
            entity.Property(e => e.LawyerId).HasColumnName("lawyer_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");

            // entity.HasOne(d => d.Entity).WithMany(p => p.Clients)
            //     .HasForeignKey(d => d.EntityId)
            //     .HasConstraintName("fk_client_entity");

            entity.HasOne(d => d.Lawyer).WithMany(p => p.Clients)
                .HasForeignKey(d => d.LawyerId)
                .HasConstraintName("fk_client_lawyer");
        });

        modelBuilder.Entity<EntityCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entities_company_pkey");

            entity.ToTable("entities_company");

            entity.Property(e => e.Id).HasColumnName("id");
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

            entity.HasOne(d => d.Entity).WithOne(p => p.EntityCompany)
                .HasForeignKey<EntityCompany>(d => d.EntityId)
                .HasConstraintName("fk_entity_company");
        });

        modelBuilder.Entity<EntityIndividual>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entities_individual_pkey");

            entity.ToTable("entities_individual");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
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

            entity.HasOne(d => d.Entity).WithOne(p => p.EntityIndividual)
                .HasForeignKey<EntityIndividual>(d => d.EntityId)
                .HasConstraintName("fk_entity_individual");
        });

        modelBuilder.Entity<EntitiesRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entities_roles_pkey");

            entity.ToTable("entities_roles");

            entity.HasIndex(e => e.Name, "entities_roles_name_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<EntitiesRolesMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entities_roles_map_pkey");

            entity.ToTable("entities_roles_map");

            entity.HasIndex(e => new { e.EntityId, e.RoleId }, "unique_entity_role").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("assigned_at");
            entity.Property(e => e.AssignedBy).HasColumnName("assigned_by");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");

            // entity.HasOne(d => d.Entity).WithMany(p => p.EntitiesRolesMaps)
            //     .HasForeignKey(d => d.EntityId)
            //     .HasConstraintName("fk_entities_roles_map_entity");

            entity.HasOne(d => d.Role).WithMany(p => p.EntitiesRolesMaps)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_entities_roles_map");
        });

        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entities_pkey");

            entity.ToTable("entities");

            entity.HasIndex(e => e.IdPublic, "entities_id_public_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EntityType)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("entity_type");
            entity.Property(e => e.IdPublic).HasColumnName("id_public");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
            
        });

        modelBuilder.Entity<JudicialProcessEntity>(entity =>
        {
            entity.ToTable("judicial_process_entity");
            
            entity.HasKey(e => new { e.JudicialProcessId, e.EntityId });
            
            entity.Property(e => e.JudicialProcessId)
                .HasColumnName("judicial_process_id");

            entity.Property(e => e.EntityId)
                .HasColumnName("entity_id");

            entity.HasOne(e => e.JudicialProcess)
                .WithMany(p => p.JudicialProcessEntities)
                .HasForeignKey(e => e.JudicialProcessId)
                .HasConstraintName("fk_judicial_process_entity_process");

            entity.HasOne(e => e.Entity)
                .WithMany(e => e.JudicialProcessEntities)
                .HasForeignKey(e => e.EntityId)
                .HasConstraintName("fk_judicial_process_entity_entity");
        });

        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("failed_jobs_pkey");

            entity.ToTable("failed_jobs");

            entity.HasIndex(e => e.Uuid, "failed_jobs_uuid_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connection).HasColumnName("connection");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.FailedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("failed_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue).HasColumnName("queue");
            entity.Property(e => e.Uuid)
                .HasMaxLength(255)
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobs_pkey");

            entity.ToTable("jobs");

            entity.HasIndex(e => e.Queue, "jobs_queue_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempts).HasColumnName("attempts");
            entity.Property(e => e.AvailableAt).HasColumnName("available_at");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue)
                .HasMaxLength(255)
                .HasColumnName("queue");
            entity.Property(e => e.ReservedAt).HasColumnName("reserved_at");
        });

        modelBuilder.Entity<JobBatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_batches_pkey");

            entity.ToTable("job_batches");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CancelledAt).HasColumnName("cancelled_at");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.FailedJobIds).HasColumnName("failed_job_ids");
            entity.Property(e => e.FailedJobs).HasColumnName("failed_jobs");
            entity.Property(e => e.FinishedAt).HasColumnName("finished_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Options).HasColumnName("options");
            entity.Property(e => e.PendingJobs).HasColumnName("pending_jobs");
            entity.Property(e => e.TotalJobs).HasColumnName("total_jobs");
        });

        modelBuilder.Entity<JudicialProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("judicial_processes_pkey");

            entity.ToTable("judicial_processes");

            entity.HasIndex(e => e.IdPublic, "judicial_processes_id_public_key").IsUnique();

            entity.HasIndex(e => e.ProcessNumber, "unique_process_number").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IdPublic).HasColumnName("id_public");
            entity.Property(e => e.InitialDate).HasColumnName("initial_date");
            entity.Property(e => e.IsArchived)
                .HasDefaultValue(false)
                .HasColumnName("is_archived");
            entity.Property(e => e.JudicialActionId).HasColumnName("judicial_action_id");
            entity.Property(e => e.NatureActionId).HasColumnName("nature_action_id");
            entity.Property(e => e.ProcessNumber)
                .HasMaxLength(20)
                .HasColumnName("process_number");
            entity.Property(e => e.Respondent)
                .HasMaxLength(255)
                .HasColumnName("respondent");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.NatureAction).WithMany(p => p.JudicialProcesses)
                .HasForeignKey(d => d.NatureActionId)
                .HasConstraintName("fk_nature_action");

            entity.HasOne(d => d.User).WithMany(p => p.JudicialProcesses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<JudicialProcessUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("judicial_process_user_pkey");

            entity.ToTable("judicial_process_user");

            entity.HasIndex(e => new { e.JudicialProcessId, e.UserId }, "unique_process_user").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessLevel)
                .HasMaxLength(50)
                .HasDefaultValueSql("'private'::character varying")
                .HasColumnName("access_level");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.JudicialProcessId).HasColumnName("judicial_process_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            // entity.HasOne(d => d.JudicialProcess).WithMany(p => p.JudicialProcessUsers)
            //     .HasForeignKey(d => d.JudicialProcessId)
            //     .HasConstraintName("fk_judicial_process");

            entity.HasOne(d => d.User).WithMany(p => p.JudicialProcessUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<JudicialAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("judicials_actions_pkey");

            entity.ToTable("judicials_actions");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Action)
                .HasMaxLength(150)
                .HasColumnName("judicial_action");
            entity.Property(e => e.NatureActionId).HasColumnName("nature_action_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.NatureAction).WithMany(p => p.JudicialAction)
                .HasForeignKey(d => d.NatureActionId)
                .HasConstraintName("fk_nature_action");
        });

        modelBuilder.Entity<LegalFee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("legal_fees_pkey");

            entity.ToTable("legal_fees");

            entity.HasIndex(e => e.IdPublic, "legal_fees_id_public_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount")
                .HasDefaultValue(0.0m);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdPublic).HasColumnName("id_public");
            entity.Property(e => e.JudicialProcessId).HasColumnName("judicial_process_id");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.QuantityInstallment)
            .HasColumnName("quantity_installment")
            .HasDefaultValue(1);
            
            entity.Property(e => e.StatusPaymentId).HasColumnName("status_payment_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.JudicialProcess).WithMany(p => p.LegalFees)
                .HasForeignKey(d => d.JudicialProcessId)
                .HasConstraintName("fk_judicial_process");

            entity.HasOne(d => d.StatusPayment).WithMany(p => p.LegalFees)
                .HasForeignKey(d => d.StatusPaymentId)
                .HasConstraintName("fk_status_payment");

            entity.HasOne(d => d.User).WithMany(p => p.LegalFees)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<LegalFeeEntity>(entity =>
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

            
        });

        modelBuilder.Entity<LegalFeesInstallment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("installments_legal_fees_pkey");

            entity.ToTable("legal_fees_installments");

            entity.HasIndex(e => e.IdPublic, "installments_legal_fees_id_public_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentInstallment).HasColumnName("current_installment");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.EntityId)
                .IsRequired()
                .HasColumnName("entity_id");
            entity.Property(e => e.IdPublic).HasColumnName("id_public");
            entity.Property(e => e.LegalFeeId).HasColumnName("legal_fee_id");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.StatusPaymentId).HasColumnName("status_payment_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.ValueInstallment).HasColumnName("value_installment");

            entity.HasOne(d => d.Entity).WithMany(p => p.LegalFeesInstallments)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("fk_legal_fee_entity");

            entity.HasOne(d => d.StatusPayment).WithMany(p => p.LegalFeesInstallments)
                .HasForeignKey(d => d.StatusPaymentId)
                .HasConstraintName("fk_status_payment");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("migrations_pkey");

            entity.ToTable("migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(255)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<NatureAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("nature_actions_pkey");

            entity.ToTable("nature_actions");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Nature)
                .HasMaxLength(50)
                .HasColumnName("nature");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PasswordResetToken>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("password_reset_tokens_pkey");

            entity.ToTable("password_reset_tokens");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
        });

        modelBuilder.Entity<PersonalAccessToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("personal_access_tokens_pkey");

            entity.ToTable("personal_access_tokens");

            entity.HasIndex(e => e.ExpiresAt, "personal_access_tokens_expires_at_index");

            entity.HasIndex(e => e.Token, "personal_access_tokens_token_unique").IsUnique();

            entity.HasIndex(e => new { e.TokenableType, e.TokenableId }, "personal_access_tokens_tokenable_type_tokenable_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abilities).HasColumnName("abilities");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.LastUsedAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("last_used_at");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .HasColumnName("token");
            entity.Property(e => e.TokenableId).HasColumnName("tokenable_id");
            entity.Property(e => e.TokenableType)
                .HasMaxLength(255)
                .HasColumnName("tokenable_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Role1)
                .HasMaxLength(30)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sessions_pkey");

            entity.ToTable("sessions");

            entity.HasIndex(e => e.LastActivity, "sessions_last_activity_index");

            entity.HasIndex(e => e.UserId, "sessions_user_id_index");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.LastActivity).HasColumnName("last_activity");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.UserAgent).HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Settlement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("installments_settlement_pkey");

            entity.ToTable("settlement");

            entity.HasIndex(e => e.IdPublic, "settlement_id_public_key").IsUnique();

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
            entity.Property(e => e.CurrentInstallment).HasColumnName("current_installment");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.IdPublic).HasColumnName("id_public");
            entity.Property(e => e.JudicialProcessId).HasColumnName("judicial_process_id");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.QuantityInstallment).HasColumnName("quantity_installment");
            entity.Property(e => e.StatusPaymentId).HasColumnName("status_payment_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ValueInstallment)
                .HasPrecision(10, 2)
                .HasComputedColumnSql("(amount / (NULLIF(quantity_installment, 0))::numeric)", true)
                .HasColumnName("value_installment");

            entity.HasOne(d => d.JudicialProcess).WithMany(p => p.Settlements)
                .HasForeignKey(d => d.JudicialProcessId)
                .HasConstraintName("fk_judicial_process");

            entity.HasOne(d => d.StatusPayment).WithMany(p => p.Settlements)
                .HasForeignKey(d => d.StatusPaymentId)
                .HasConstraintName("fk_status_payment");

            entity.HasOne(d => d.User).WithMany(p => p.Settlements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<StatusEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_entities_pkey");

            entity.ToTable("status_entities");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .HasColumnName("description");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<StatusPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_payment_pkey");

            entity.ToTable("status_payment");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .HasColumnName("description");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();

            entity.HasIndex(e => e.IdPublic, "users_id_public_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.EmailVerifiedAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("email_verified_at");
            entity.Property(e => e.IdPublic).HasColumnName("id_public");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.ProfilePhotoPath)
                .HasMaxLength(2048)
                .HasColumnName("profile_photo_path");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            entity.Property(e => e.TwoFactorConfirmedAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("two_factor_confirmed_at");
            entity.Property(e => e.TwoFactorRecoveryCodes).HasColumnName("two_factor_recovery_codes");
            entity.Property(e => e.TwoFactorSecret).HasColumnName("two_factor_secret");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("updated_at");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("user_roles_pkey");
                        j.ToTable("user_roles");
                        j.IndexerProperty<long>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

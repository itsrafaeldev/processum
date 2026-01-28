using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace processum.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cache",
                columns: table => new
                {
                    key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    expiration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cache_pkey", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "cache_locks",
                columns: table => new
                {
                    key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    owner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    expiration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cache_locks_pkey", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "entities",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entity_type = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    id_public = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("entities_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "entities_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("entities_roles_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "failed_jobs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    connection = table.Column<string>(type: "text", nullable: false),
                    queue = table.Column<string>(type: "text", nullable: false),
                    payload = table.Column<string>(type: "text", nullable: false),
                    exception = table.Column<string>(type: "text", nullable: false),
                    failed_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("failed_jobs_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_batches",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    total_jobs = table.Column<int>(type: "integer", nullable: false),
                    pending_jobs = table.Column<int>(type: "integer", nullable: false),
                    failed_jobs = table.Column<int>(type: "integer", nullable: false),
                    failed_job_ids = table.Column<string>(type: "text", nullable: false),
                    options = table.Column<string>(type: "text", nullable: true),
                    cancelled_at = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<int>(type: "integer", nullable: false),
                    finished_at = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_batches_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    queue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    payload = table.Column<string>(type: "text", nullable: false),
                    attempts = table.Column<short>(type: "smallint", nullable: false),
                    reserved_at = table.Column<int>(type: "integer", nullable: true),
                    available_at = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("jobs_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "migrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    migration = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    batch = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("migrations_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nature_actions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    nature = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("nature_actions_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "password_reset_tokens",
                columns: table => new
                {
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("password_reset_tokens_pkey", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "personal_access_tokens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tokenable_type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tokenable_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    token = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    abilities = table.Column<string>(type: "text", nullable: true),
                    last_used_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    expires_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("personal_access_tokens_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    role = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    ip_address = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    user_agent = table.Column<string>(type: "text", nullable: true),
                    payload = table.Column<string>(type: "text", nullable: false),
                    last_activity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sessions_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status_entities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    description = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("status_entities_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status_payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    description = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("status_payment_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email_verified_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    remember_token = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    profile_photo_path = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    two_factor_secret = table.Column<string>(type: "text", nullable: true),
                    two_factor_recovery_codes = table.Column<string>(type: "text", nullable: true),
                    two_factor_confirmed_at = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    id_public = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "entities_company",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entity_id = table.Column<long>(type: "bigint", nullable: false),
                    cnpj = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    corporate_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    trade_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("entities_company_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_entity_company",
                        column: x => x.entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entities_individual",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entity_id = table.Column<long>(type: "bigint", nullable: false),
                    cpf = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    rg = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("entities_individual_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_entity_individual",
                        column: x => x.entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entities_roles_map",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entity_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    assigned_by = table.Column<long>(type: "bigint", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("entities_roles_map_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_entities_roles_map_entities_entity_id",
                        column: x => x.entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_entities_roles_map",
                        column: x => x.role_id,
                        principalTable: "entities_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "judicials_actions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    judicial_action = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    nature_action_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("judicials_actions_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_nature_action",
                        column: x => x.nature_action_id,
                        principalTable: "nature_actions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legal_fees_installments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_public = table.Column<Guid>(type: "uuid", nullable: false),
                    current_installment = table.Column<int>(type: "integer", nullable: false),
                    legal_fee_id = table.Column<int>(type: "integer", nullable: false),
                    value_installment = table.Column<decimal>(type: "numeric", nullable: false),
                    status_payment_id = table.Column<int>(type: "integer", nullable: false),
                    payment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    due_date = table.Column<DateOnly>(type: "date", nullable: true),
                    note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    entity_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("installments_legal_fees_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_legal_fee_entity",
                        column: x => x.entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_status_payment",
                        column: x => x.status_payment_id,
                        principalTable: "status_payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    lawyer_id = table.Column<long>(type: "bigint", nullable: false),
                    entity_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clients_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_clients_entities_entity_id",
                        column: x => x.entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_client_lawyer",
                        column: x => x.lawyer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_roles_pkey", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_role",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "judicial_processes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    process_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    initial_date = table.Column<DateOnly>(type: "date", nullable: false),
                    respondent = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    nature_action_id = table.Column<int>(type: "integer", nullable: false),
                    judicial_action_id = table.Column<int>(type: "integer", nullable: false),
                    is_archived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    id_public = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("judicial_processes_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_judicial_processes_judicials_actions_judicial_action_id",
                        column: x => x.judicial_action_id,
                        principalTable: "judicials_actions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_nature_action",
                        column: x => x.nature_action_id,
                        principalTable: "nature_actions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "judicial_process_entity",
                columns: table => new
                {
                    judicial_process_id = table.Column<long>(type: "bigint", nullable: false),
                    entity_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_judicial_process_entity", x => new { x.judicial_process_id, x.entity_id });
                    table.ForeignKey(
                        name: "fk_judicial_process_entity_entity",
                        column: x => x.entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_judicial_process_entity_process",
                        column: x => x.judicial_process_id,
                        principalTable: "judicial_processes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "judicial_process_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    judicial_process_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    access_level = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'private'::character varying"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("judicial_process_user_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_judicial_process_user_judicial_processes_judicial_process_id",
                        column: x => x.judicial_process_id,
                        principalTable: "judicial_processes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legal_fees",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0.0m),
                    quantity_installment = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    judicial_process_id = table.Column<long>(type: "bigint", nullable: false),
                    status_payment_id = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    id_public = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("legal_fees_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_judicial_process",
                        column: x => x.judicial_process_id,
                        principalTable: "judicial_processes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_status_payment",
                        column: x => x.status_payment_id,
                        principalTable: "status_payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "settlement",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    quantity_installment = table.Column<int>(type: "integer", nullable: false),
                    current_installment = table.Column<int>(type: "integer", nullable: false),
                    judicial_process_id = table.Column<long>(type: "bigint", nullable: false),
                    value_installment = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true, computedColumnSql: "(amount / (NULLIF(quantity_installment, 0))::numeric)", stored: true),
                    status_payment_id = table.Column<int>(type: "integer", nullable: false),
                    payment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    due_date = table.Column<DateOnly>(type: "date", nullable: true),
                    competence = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    id_public = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("installments_settlement_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_judicial_process",
                        column: x => x.judicial_process_id,
                        principalTable: "judicial_processes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_status_payment",
                        column: x => x.status_payment_id,
                        principalTable: "status_payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legal_fee_entity",
                columns: table => new
                {
                    legal_fee_id = table.Column<long>(type: "bigint", nullable: false),
                    entity_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_legal_fee_entity", x => new { x.legal_fee_id, x.entity_id });
                    table.ForeignKey(
                        name: "fk_legal_fee_entity_entity",
                        column: x => x.entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legal_fee_entity_legal_fee",
                        column: x => x.legal_fee_id,
                        principalTable: "legal_fees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_entity_id",
                table: "clients",
                column: "entity_id");

            migrationBuilder.CreateIndex(
                name: "IX_clients_lawyer_id",
                table: "clients",
                column: "lawyer_id");

            migrationBuilder.CreateIndex(
                name: "entities_id_public_key",
                table: "entities",
                column: "id_public",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entities_company_entity_id",
                table: "entities_company",
                column: "entity_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entities_individual_entity_id",
                table: "entities_individual",
                column: "entity_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "entities_roles_name_key",
                table: "entities_roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entities_roles_map_role_id",
                table: "entities_roles_map",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "unique_entity_role",
                table: "entities_roles_map",
                columns: new[] { "entity_id", "role_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "failed_jobs_uuid_unique",
                table: "failed_jobs",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "jobs_queue_index",
                table: "jobs",
                column: "queue");

            migrationBuilder.CreateIndex(
                name: "IX_judicial_process_entity_entity_id",
                table: "judicial_process_entity",
                column: "entity_id");

            migrationBuilder.CreateIndex(
                name: "IX_judicial_process_user_user_id",
                table: "judicial_process_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "unique_process_user",
                table: "judicial_process_user",
                columns: new[] { "judicial_process_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_judicial_processes_judicial_action_id",
                table: "judicial_processes",
                column: "judicial_action_id");

            migrationBuilder.CreateIndex(
                name: "IX_judicial_processes_nature_action_id",
                table: "judicial_processes",
                column: "nature_action_id");

            migrationBuilder.CreateIndex(
                name: "IX_judicial_processes_user_id",
                table: "judicial_processes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "judicial_processes_id_public_key",
                table: "judicial_processes",
                column: "id_public",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_process_number",
                table: "judicial_processes",
                column: "process_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_judicials_actions_nature_action_id",
                table: "judicials_actions",
                column: "nature_action_id");

            migrationBuilder.CreateIndex(
                name: "IX_legal_fee_entity_entity_id",
                table: "legal_fee_entity",
                column: "entity_id");

            migrationBuilder.CreateIndex(
                name: "IX_legal_fees_judicial_process_id",
                table: "legal_fees",
                column: "judicial_process_id");

            migrationBuilder.CreateIndex(
                name: "IX_legal_fees_status_payment_id",
                table: "legal_fees",
                column: "status_payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_legal_fees_user_id",
                table: "legal_fees",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "legal_fees_id_public_key",
                table: "legal_fees",
                column: "id_public",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "installments_legal_fees_id_public_key",
                table: "legal_fees_installments",
                column: "id_public",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_legal_fees_installments_entity_id",
                table: "legal_fees_installments",
                column: "entity_id");

            migrationBuilder.CreateIndex(
                name: "IX_legal_fees_installments_status_payment_id",
                table: "legal_fees_installments",
                column: "status_payment_id");

            migrationBuilder.CreateIndex(
                name: "personal_access_tokens_expires_at_index",
                table: "personal_access_tokens",
                column: "expires_at");

            migrationBuilder.CreateIndex(
                name: "personal_access_tokens_token_unique",
                table: "personal_access_tokens",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "personal_access_tokens_tokenable_type_tokenable_id_index",
                table: "personal_access_tokens",
                columns: new[] { "tokenable_type", "tokenable_id" });

            migrationBuilder.CreateIndex(
                name: "sessions_last_activity_index",
                table: "sessions",
                column: "last_activity");

            migrationBuilder.CreateIndex(
                name: "sessions_user_id_index",
                table: "sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_judicial_process_id",
                table: "settlement",
                column: "judicial_process_id");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_status_payment_id",
                table: "settlement",
                column: "status_payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_user_id",
                table: "settlement",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "settlement_id_public_key",
                table: "settlement",
                column: "id_public",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "users_email_unique",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_id_public_key",
                table: "users",
                column: "id_public",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cache");

            migrationBuilder.DropTable(
                name: "cache_locks");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "entities_company");

            migrationBuilder.DropTable(
                name: "entities_individual");

            migrationBuilder.DropTable(
                name: "entities_roles_map");

            migrationBuilder.DropTable(
                name: "failed_jobs");

            migrationBuilder.DropTable(
                name: "job_batches");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "judicial_process_entity");

            migrationBuilder.DropTable(
                name: "judicial_process_user");

            migrationBuilder.DropTable(
                name: "legal_fee_entity");

            migrationBuilder.DropTable(
                name: "legal_fees_installments");

            migrationBuilder.DropTable(
                name: "migrations");

            migrationBuilder.DropTable(
                name: "password_reset_tokens");

            migrationBuilder.DropTable(
                name: "personal_access_tokens");

            migrationBuilder.DropTable(
                name: "sessions");

            migrationBuilder.DropTable(
                name: "settlement");

            migrationBuilder.DropTable(
                name: "status_entities");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "entities_roles");

            migrationBuilder.DropTable(
                name: "legal_fees");

            migrationBuilder.DropTable(
                name: "entities");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "judicial_processes");

            migrationBuilder.DropTable(
                name: "status_payment");

            migrationBuilder.DropTable(
                name: "judicials_actions");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "nature_actions");
        }
    }
}

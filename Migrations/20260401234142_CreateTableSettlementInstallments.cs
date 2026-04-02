using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OctaPro.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableSettlementInstallments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "value_installment",
                table: "settlement");

            migrationBuilder.DropColumn(
                name: "competence",
                table: "settlement");

            migrationBuilder.DropColumn(
                name: "current_installment",
                table: "settlement");

            migrationBuilder.DropColumn(
                name: "due_date",
                table: "settlement");

            migrationBuilder.DropColumn(
                name: "payment_date",
                table: "settlement");

            migrationBuilder.CreateTable(
                name: "settlement_installments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Document = table.Column<int>(type: "integer", nullable: false),
                    ValueInstallment = table.Column<decimal>(type: "numeric", nullable: true),
                    StatusPaymentId = table.Column<int>(type: "integer", nullable: false),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Competence = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    IdPublic = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementInstallments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettlementInstallments_status_payment_StatusPaymentId",
                        column: x => x.StatusPaymentId,
                        principalTable: "status_payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.Sql(
                "ALTER SEQUENCE \"settlement_installments_Id_seq\" RESTART WITH 1000;"
            );

            migrationBuilder.CreateIndex(
                name: "IX_SettlementInstallments_StatusPaymentId",
                table: "settlement_installments",
                column: "StatusPaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "settlement_installments");

            migrationBuilder.AddColumn<string>(
                name: "competence",
                table: "settlement",
                type: "character varying(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "current_installment",
                table: "settlement",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "due_date",
                table: "settlement",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "payment_date",
                table: "settlement",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "value_installment",
                table: "settlement",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                computedColumnSql: "(amount / (NULLIF(quantity_installment, 0))::numeric)",
                stored: true);
        }
    }
}

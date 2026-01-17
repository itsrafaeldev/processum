using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace processum.Migrations
{
    /// <inheritdoc />
    public partial class DefingDefaultValuesToAmountAndQuantityInstallmentsInLegalFee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_client_entity",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "fk_entities_roles_map_entity",
                table: "entities_roles_map");

            migrationBuilder.DropColumn(
                name: "ie",
                table: "entities_company");

            migrationBuilder.AlterColumn<int>(
                name: "quantity_installment",
                table: "legal_fees",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "legal_fees",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0.0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.CreateIndex(
                name: "IX_judicial_processes_judicial_action_id",
                table: "judicial_processes",
                column: "judicial_action_id");

            migrationBuilder.CreateIndex(
                name: "IX_entities_individual_entity_id",
                table: "entities_individual",
                column: "entity_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entities_company_entity_id",
                table: "entities_company",
                column: "entity_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_clients_entities_entity_id",
                table: "clients",
                column: "entity_id",
                principalTable: "entities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_entities_roles_map_entities_entity_id",
                table: "entities_roles_map",
                column: "entity_id",
                principalTable: "entities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_judicial_processes_judicials_actions_judicial_action_id",
                table: "judicial_processes",
                column: "judicial_action_id",
                principalTable: "judicials_actions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_entities_entity_id",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_entities_roles_map_entities_entity_id",
                table: "entities_roles_map");

            migrationBuilder.DropForeignKey(
                name: "FK_judicial_processes_judicials_actions_judicial_action_id",
                table: "judicial_processes");

            migrationBuilder.DropIndex(
                name: "IX_judicial_processes_judicial_action_id",
                table: "judicial_processes");

            migrationBuilder.DropIndex(
                name: "IX_entities_individual_entity_id",
                table: "entities_individual");

            migrationBuilder.DropIndex(
                name: "IX_entities_company_entity_id",
                table: "entities_company");

            migrationBuilder.AlterColumn<int>(
                name: "quantity_installment",
                table: "legal_fees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "legal_fees",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldDefaultValue: 0.0m);


            migrationBuilder.AddColumn<string>(
                name: "ie",
                table: "entities_company",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_entities_individual_entity_id",
                table: "entities_individual",
                column: "entity_id");

            migrationBuilder.CreateIndex(
                name: "IX_entities_company_entity_id",
                table: "entities_company",
                column: "entity_id");

            migrationBuilder.AddForeignKey(
                name: "fk_client_entity",
                table: "clients",
                column: "entity_id",
                principalTable: "entities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_entities_roles_map_entity",
                table: "entities_roles_map",
                column: "entity_id",
                principalTable: "entities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

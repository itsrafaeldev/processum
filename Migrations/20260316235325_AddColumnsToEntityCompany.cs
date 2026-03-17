using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OctaPro.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToEntityCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "entities_company",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "entities_company",
                type: "character varying(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "entities_company",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "complement",
                table: "entities_company",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "district",
                table: "entities_company",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "house_number",
                table: "entities_company",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uf",
                table: "entities_company",
                type: "character varying(2)",
                maxLength: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "entities_company");

            migrationBuilder.DropColumn(
                name: "cep",
                table: "entities_company");

            migrationBuilder.DropColumn(
                name: "city",
                table: "entities_company");

            migrationBuilder.DropColumn(
                name: "complement",
                table: "entities_company");

            migrationBuilder.DropColumn(
                name: "district",
                table: "entities_company");

            migrationBuilder.DropColumn(
                name: "house_number",
                table: "entities_company");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "entities_company");
        }
    }
}

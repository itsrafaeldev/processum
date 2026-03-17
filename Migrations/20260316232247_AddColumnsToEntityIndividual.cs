using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OctaPro.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToEntityIndividual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "entities_individual",
                type: "character varying(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "house_number",
                table: "entities_individual",
                type: "character varying(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "complement",
                table: "entities_individual",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "entities_individual",
                type: "character varying(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "district",
                table: "entities_individual",
                type: "character varying(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uf",
                table: "entities_individual",
                type: "character varying(2)",
                maxLength: 2,
                nullable: true);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "cep",
                table: "entities_individual");

            migrationBuilder.DropColumn(
                name: "city",
                table: "entities_individual");

            migrationBuilder.DropColumn(
                name: "complement",
                table: "entities_individual");

            migrationBuilder.DropColumn(
                name: "district",
                table: "entities_individual");

            migrationBuilder.DropColumn(
                name: "house_number",
                table: "entities_individual");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "entities_individual");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OctaPro.Migrations
{
    /// <inheritdoc />
    public partial class InsertValuesToTableStatusEntities : Migration
    {
       
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO status_entities (description) VALUES ('A');");
            migrationBuilder.Sql("INSERT INTO status_entities (description) VALUES ('D');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM status_entities WHERE description = 'A';");
            migrationBuilder.Sql("DELETE FROM status_entities WHERE description = 'D';");
        }
    }
}

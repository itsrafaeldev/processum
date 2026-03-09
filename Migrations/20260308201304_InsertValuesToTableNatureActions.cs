using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OctaPro.Migrations
{
    /// <inheritdoc />
    public partial class InsertValuesToTableNatureActions : Migration
    {
       protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO nature_actions (nature) VALUES ('Direito Cível');");
            migrationBuilder.Sql("INSERT INTO nature_actions (nature) VALUES ('Direito Trabalhista');");
            migrationBuilder.Sql("INSERT INTO nature_actions (nature) VALUES ('Direito Penal');");
            migrationBuilder.Sql("INSERT INTO nature_actions (nature) VALUES ('Direito Tributário');");
            migrationBuilder.Sql("INSERT INTO nature_actions (nature) VALUES ('Direito Administrativo');");
            migrationBuilder.Sql("INSERT INTO nature_actions (nature) VALUES ('Família e Sucessões');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM nature_actions WHERE nature = 'Direito Cível';");
            migrationBuilder.Sql("DELETE FROM nature_actions WHERE nature = 'Direito Trabalhista';");
            migrationBuilder.Sql("DELETE FROM nature_actions WHERE nature = 'Direito Penal';");
            migrationBuilder.Sql("DELETE FROM nature_actions WHERE nature = 'Direito Tributário';");
            migrationBuilder.Sql("DELETE FROM nature_actions WHERE nature = 'Direito Administrativo';");
            migrationBuilder.Sql("DELETE FROM nature_actions WHERE nature = 'Família e Sucessões';");
        }
    }
}

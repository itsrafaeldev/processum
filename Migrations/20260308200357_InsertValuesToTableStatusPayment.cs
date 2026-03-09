using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OctaPro.Migrations
{
    /// <inheritdoc />
    public partial class InsertValuesToTableStatusPayment : Migration
    {
       protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO status_payment (description) VALUES ('Pago');");
            migrationBuilder.Sql("INSERT INTO status_payment (description) VALUES ('Pendente');");
            migrationBuilder.Sql("INSERT INTO status_payment (description) VALUES ('Atrasado');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM status_payment WHERE description = 'Pago';");
            migrationBuilder.Sql("DELETE FROM status_payment WHERE description = 'Pendente';");
            migrationBuilder.Sql("DELETE FROM status_payment WHERE description = 'Atrasado';");
        }
    }
}

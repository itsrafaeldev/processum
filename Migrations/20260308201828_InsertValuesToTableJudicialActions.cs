using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OctaPro.Migrations
{
    /// <inheritdoc />
    public partial class InsertValuesToTableJudicialActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de indenização / Ação de reparação de danos', 1);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de cobrança / Cobrança judicial', 1);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de despejo', 1);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de alimentos', 1);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de usucapião', 1);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação declaratória', 1);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de obrigação de fazer / não fazer', 1);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Inventário / Partilha', 1);");

            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Reclamação trabalhista', 2);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de horas extras', 2);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de adicional de insalubridade / periculosidade', 2);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de equiparação salarial', 2);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de rescisão contratual', 2);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de indenização por acidente de trabalho', 2);");

            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação penal pública', 3);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação penal privada', 3);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Queixa-crime', 3);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Medidas protetivas em casos de violência', 3);");

            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de execução fiscal', 4);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Mandado de segurança contra lançamento tributário', 4);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação anulatória de débito fiscal', 4);");

            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Ação de improbidade administrativa', 5);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Mandado de segurança contra ato administrativo', 5);");

            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Divórcio / Separação judicial', 6);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Guarda e tutela', 6);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Adoção', 6);");
            migrationBuilder.Sql("INSERT INTO judicials_actions (judicial_action, nature_action_id) VALUES ('Alimentos', 6);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de indenização / Ação de reparação de danos';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de cobrança / Cobrança judicial';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de despejo';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de alimentos';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de usucapião';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação declaratória';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de obrigação de fazer / não fazer';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Inventário / Partilha';");

            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Reclamação trabalhista';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de horas extras';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de adicional de insalubridade / periculosidade';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de equiparação salarial';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de rescisão contratual';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de indenização por acidente de trabalho';");

            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação penal pública';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação penal privada';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Queixa-crime';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Medidas protetivas em casos de violência';");

            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de execução fiscal';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Mandado de segurança contra lançamento tributário';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação anulatória de débito fiscal';");

            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Ação de improbidade administrativa';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Mandado de segurança contra ato administrativo';");

            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Divórcio / Separação judicial';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Guarda e tutela';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Adoção';");
            migrationBuilder.Sql("DELETE FROM judicials_actions WHERE judicial_action = 'Alimentos';");
        }
    }
}

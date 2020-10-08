using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda_WPF.Migrations
{
    public partial class DefesaadicionarcampoPesoeCelularCadastrarPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Pacientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Pacientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Medicos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Medicos");
        }
    }
}

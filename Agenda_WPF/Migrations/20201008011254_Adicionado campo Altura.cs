using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda_WPF.Migrations
{
    public partial class AdicionadocampoAltura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Medicos");

            migrationBuilder.AddColumn<string>(
                name: "Altura",
                table: "Pacientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Pacientes");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

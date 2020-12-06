using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda_WEB.Migrations
{
    public partial class Atualizandotabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medico_MedicoId",
                table: "Consultas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medico",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Pacientes");

            migrationBuilder.RenameTable(
                name: "Medico",
                newName: "Medicos");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nascimento",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Pacientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Pacientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Pacientes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoraConsulta",
                table: "Consultas",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nascimento",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nascimento",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_MedicoId",
                table: "Consultas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_MedicoId",
                table: "Consultas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nascimento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nascimento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Nascimento",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Medicos");

            migrationBuilder.RenameTable(
                name: "Medicos",
                newName: "Medico");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraConsulta",
                table: "Consultas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medico",
                table: "Medico",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medico_MedicoId",
                table: "Consultas",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

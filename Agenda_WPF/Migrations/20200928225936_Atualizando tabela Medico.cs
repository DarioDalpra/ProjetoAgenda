using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda_WPF.Migrations
{
    public partial class AtualizandotabelaMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    IdMedico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    Nascimento = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Crm = table.Column<string>(nullable: true),
                    Especialidade = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.IdMedico);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    Nascimento = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    NomePlano = table.Column<string>(nullable: true),
                    NumPlano = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    Nascimento = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Administrador = table.Column<bool>(nullable: false),
                    Medico = table.Column<bool>(nullable: false),
                    Atendente = table.Column<bool>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    IdAgenda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeIdPaciente = table.Column<int>(nullable: true),
                    CpfIdPaciente = table.Column<int>(nullable: true),
                    PlanoIdPaciente = table.Column<int>(nullable: true),
                    NomeMedicoIdMedico = table.Column<int>(nullable: true),
                    EspecialidadeIdMedico = table.Column<int>(nullable: true),
                    DataAgendada = table.Column<DateTime>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.IdAgenda);
                    table.ForeignKey(
                        name: "FK_Agendas_Pacientes_CpfIdPaciente",
                        column: x => x.CpfIdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Medicos_EspecialidadeIdMedico",
                        column: x => x.EspecialidadeIdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Pacientes_NomeIdPaciente",
                        column: x => x.NomeIdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Medicos_NomeMedicoIdMedico",
                        column: x => x.NomeMedicoIdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Pacientes_PlanoIdPaciente",
                        column: x => x.PlanoIdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prontuario",
                columns: table => new
                {
                    IdProntuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePacienteIdPaciente = table.Column<int>(nullable: true),
                    NomeMedicoIdMedico = table.Column<int>(nullable: true),
                    Sintomas = table.Column<string>(nullable: true),
                    Avaliacao = table.Column<string>(nullable: true),
                    Medicamento = table.Column<string>(nullable: true),
                    PlanoSaude = table.Column<string>(nullable: true),
                    DataConsulta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuario", x => x.IdProntuario);
                    table.ForeignKey(
                        name: "FK_Prontuario_Medicos_NomeMedicoIdMedico",
                        column: x => x.NomeMedicoIdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prontuario_Pacientes_NomePacienteIdPaciente",
                        column: x => x.NomePacienteIdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_CpfIdPaciente",
                table: "Agendas",
                column: "CpfIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_EspecialidadeIdMedico",
                table: "Agendas",
                column: "EspecialidadeIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_NomeIdPaciente",
                table: "Agendas",
                column: "NomeIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_NomeMedicoIdMedico",
                table: "Agendas",
                column: "NomeMedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_PlanoIdPaciente",
                table: "Agendas",
                column: "PlanoIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_NomeMedicoIdMedico",
                table: "Prontuario",
                column: "NomeMedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_NomePacienteIdPaciente",
                table: "Prontuario",
                column: "NomePacienteIdPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Prontuario");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}

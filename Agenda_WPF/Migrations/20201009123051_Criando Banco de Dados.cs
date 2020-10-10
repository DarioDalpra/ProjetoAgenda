using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda_WPF.Migrations
{
    public partial class CriandoBancodeDados : Migration
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
                    Peso = table.Column<double>(nullable: false),
                    Altura = table.Column<double>(nullable: false),
                    Imc = table.Column<double>(nullable: false),
                    Celular = table.Column<string>(nullable: true),
                    NomePlano = table.Column<string>(nullable: true),
                    NumPlano = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "tbPlanoSaude",
                columns: table => new
                {
                    PlanoSaudeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plano = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPlanoSaude", x => x.PlanoSaudeId);
                });

            migrationBuilder.CreateTable(
                name: "tbProcedimentos",
                columns: table => new
                {
                    ProcedimentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProcedimento = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProcedimentos", x => x.ProcedimentoId);
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
                name: "Agenda",
                columns: table => new
                {
                    IdAgenda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteIdPaciente = table.Column<int>(nullable: true),
                    CpfIdPaciente = table.Column<int>(nullable: true),
                    Plano = table.Column<string>(nullable: true),
                    MedicoIdMedico = table.Column<int>(nullable: true),
                    EspecialidadeIdMedico = table.Column<int>(nullable: true),
                    DataAgendada = table.Column<DateTime>(nullable: false),
                    HoraAgendada = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.IdAgenda);
                    table.ForeignKey(
                        name: "FK_Agenda_Pacientes_CpfIdPaciente",
                        column: x => x.CpfIdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agenda_Medicos_EspecialidadeIdMedico",
                        column: x => x.EspecialidadeIdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agenda_Medicos_MedicoIdMedico",
                        column: x => x.MedicoIdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agenda_Pacientes_PacienteIdPaciente",
                        column: x => x.PacienteIdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prontuarios",
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
                    table.PrimaryKey("PK_Prontuarios", x => x.IdProntuario);
                    table.ForeignKey(
                        name: "FK_Prontuarios_Medicos_NomeMedicoIdMedico",
                        column: x => x.NomeMedicoIdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prontuarios_Pacientes_NomePacienteIdPaciente",
                        column: x => x.NomePacienteIdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_CpfIdPaciente",
                table: "Agenda",
                column: "CpfIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_EspecialidadeIdMedico",
                table: "Agenda",
                column: "EspecialidadeIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_MedicoIdMedico",
                table: "Agenda",
                column: "MedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PacienteIdPaciente",
                table: "Agenda",
                column: "PacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_NomeMedicoIdMedico",
                table: "Prontuarios",
                column: "NomeMedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_NomePacienteIdPaciente",
                table: "Prontuarios",
                column: "NomePacienteIdPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Prontuarios");

            migrationBuilder.DropTable(
                name: "tbPlanoSaude");

            migrationBuilder.DropTable(
                name: "tbProcedimentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}

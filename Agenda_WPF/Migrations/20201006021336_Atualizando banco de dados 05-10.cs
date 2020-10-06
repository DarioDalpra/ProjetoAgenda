using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda_WPF.Migrations
{
    public partial class Atualizandobancodedados0510 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Pacientes_CpfIdPaciente",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Medicos_EspecialidadeIdMedico",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Pacientes_NomeIdPaciente",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Medicos_NomeMedicoIdMedico",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Pacientes_PlanoIdPaciente",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Prontuario_Medicos_NomeMedicoIdMedico",
                table: "Prontuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Prontuario_Pacientes_NomePacienteIdPaciente",
                table: "Prontuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prontuario",
                table: "Prontuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_NomeIdPaciente",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_NomeMedicoIdMedico",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_PlanoIdPaciente",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "NomeIdPaciente",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "NomeMedicoIdMedico",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "PlanoIdPaciente",
                table: "Agendas");

            migrationBuilder.RenameTable(
                name: "Prontuario",
                newName: "Prontuarios");

            migrationBuilder.RenameTable(
                name: "Agendas",
                newName: "Agenda");

            migrationBuilder.RenameIndex(
                name: "IX_Prontuario_NomePacienteIdPaciente",
                table: "Prontuarios",
                newName: "IX_Prontuarios_NomePacienteIdPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_Prontuario_NomeMedicoIdMedico",
                table: "Prontuarios",
                newName: "IX_Prontuarios_NomeMedicoIdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_EspecialidadeIdMedico",
                table: "Agenda",
                newName: "IX_Agenda_EspecialidadeIdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_CpfIdPaciente",
                table: "Agenda",
                newName: "IX_Agenda_CpfIdPaciente");

            migrationBuilder.AddColumn<string>(
                name: "HoraAgendada",
                table: "Agenda",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicoIdMedico",
                table: "Agenda",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteIdPaciente",
                table: "Agenda",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plano",
                table: "Agenda",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prontuarios",
                table: "Prontuarios",
                column: "IdProntuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agenda",
                table: "Agenda",
                column: "IdAgenda");

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

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_MedicoIdMedico",
                table: "Agenda",
                column: "MedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PacienteIdPaciente",
                table: "Agenda",
                column: "PacienteIdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Pacientes_CpfIdPaciente",
                table: "Agenda",
                column: "CpfIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Medicos_EspecialidadeIdMedico",
                table: "Agenda",
                column: "EspecialidadeIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Medicos_MedicoIdMedico",
                table: "Agenda",
                column: "MedicoIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Pacientes_PacienteIdPaciente",
                table: "Agenda",
                column: "PacienteIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuarios_Medicos_NomeMedicoIdMedico",
                table: "Prontuarios",
                column: "NomeMedicoIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuarios_Pacientes_NomePacienteIdPaciente",
                table: "Prontuarios",
                column: "NomePacienteIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Pacientes_CpfIdPaciente",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Medicos_EspecialidadeIdMedico",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Medicos_MedicoIdMedico",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Pacientes_PacienteIdPaciente",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Prontuarios_Medicos_NomeMedicoIdMedico",
                table: "Prontuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Prontuarios_Pacientes_NomePacienteIdPaciente",
                table: "Prontuarios");

            migrationBuilder.DropTable(
                name: "tbPlanoSaude");

            migrationBuilder.DropTable(
                name: "tbProcedimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prontuarios",
                table: "Prontuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agenda",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_MedicoIdMedico",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_PacienteIdPaciente",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "HoraAgendada",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "MedicoIdMedico",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "PacienteIdPaciente",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "Plano",
                table: "Agenda");

            migrationBuilder.RenameTable(
                name: "Prontuarios",
                newName: "Prontuario");

            migrationBuilder.RenameTable(
                name: "Agenda",
                newName: "Agendas");

            migrationBuilder.RenameIndex(
                name: "IX_Prontuarios_NomePacienteIdPaciente",
                table: "Prontuario",
                newName: "IX_Prontuario_NomePacienteIdPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_Prontuarios_NomeMedicoIdMedico",
                table: "Prontuario",
                newName: "IX_Prontuario_NomeMedicoIdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_EspecialidadeIdMedico",
                table: "Agendas",
                newName: "IX_Agendas_EspecialidadeIdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_CpfIdPaciente",
                table: "Agendas",
                newName: "IX_Agendas_CpfIdPaciente");

            migrationBuilder.AddColumn<int>(
                name: "NomeIdPaciente",
                table: "Agendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NomeMedicoIdMedico",
                table: "Agendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanoIdPaciente",
                table: "Agendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prontuario",
                table: "Prontuario",
                column: "IdProntuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas",
                column: "IdAgenda");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Pacientes_CpfIdPaciente",
                table: "Agendas",
                column: "CpfIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Medicos_EspecialidadeIdMedico",
                table: "Agendas",
                column: "EspecialidadeIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Pacientes_NomeIdPaciente",
                table: "Agendas",
                column: "NomeIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Medicos_NomeMedicoIdMedico",
                table: "Agendas",
                column: "NomeMedicoIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Pacientes_PlanoIdPaciente",
                table: "Agendas",
                column: "PlanoIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuario_Medicos_NomeMedicoIdMedico",
                table: "Prontuario",
                column: "NomeMedicoIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuario_Pacientes_NomePacienteIdPaciente",
                table: "Prontuario",
                column: "NomePacienteIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

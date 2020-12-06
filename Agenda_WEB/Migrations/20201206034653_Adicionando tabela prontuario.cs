using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda_WEB.Migrations
{
    public partial class Adicionandotabelaprontuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false),
                    Sintomas = table.Column<string>(nullable: true),
                    Avaliacao = table.Column<string>(nullable: true),
                    Medicamento = table.Column<string>(nullable: true),
                    PlanoSaude = table.Column<string>(nullable: true),
                    DataConsulta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prontuarios_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prontuarios_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_MedicoId",
                table: "Prontuarios",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_PacienteId",
                table: "Prontuarios",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prontuarios");
        }
    }
}

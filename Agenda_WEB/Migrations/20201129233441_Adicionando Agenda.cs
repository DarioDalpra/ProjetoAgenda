using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda_WEB.Migrations
{
    public partial class AdicionandoAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgenda = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: true),
                    CpfId = table.Column<int>(nullable: true),
                    Plano = table.Column<string>(nullable: true),
                    MedicoId = table.Column<int>(nullable: true),
                    EspecialidadeId = table.Column<int>(nullable: true),
                    DataAgendada = table.Column<DateTime>(nullable: false),
                    HoraAgendada = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Pacientes_CpfId",
                        column: x => x.CpfId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agenda_Medico_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agenda_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agenda_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_CpfId",
                table: "Agenda",
                column: "CpfId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_EspecialidadeId",
                table: "Agenda",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_MedicoId",
                table: "Agenda",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PacienteId",
                table: "Agenda",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");
        }
    }
}

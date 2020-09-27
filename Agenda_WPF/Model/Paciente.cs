using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WPF.Model
{
    [Table("Pacientes")]
    class Paciente : Pessoa
    {
        public Paciente() => CriadoEm = DateTime.Now;

        [Key]
        public int IdPaciente { get; set; }
        public string NomePlano { get; set; }
        public string NumPlano { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
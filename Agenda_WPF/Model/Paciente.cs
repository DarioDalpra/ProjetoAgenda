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

        public double Peso { get; set; }
        public double Altura { get; set; }

        public double Imc { get; set; }
        public string Celular { get; set; }


        public string NomePlano { get; set; }
        public string NumPlano { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
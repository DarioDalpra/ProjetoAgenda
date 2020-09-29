using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Agenda_WPF.Model
{
    [Table("Agendas")]
    class Agenda
    {
        public Agenda() => CriadoEm = DateTime.Now;

        [Key]
        public int IdAgenda { get; set; }
        public Paciente Nome { get; set; }
        public Paciente Cpf { get; set; }
        public Paciente Plano { get; set; }
        public Medico NomeMedico { get; set; }
        public Medico Especialidade { get; set; }

        public List<Prontuario> Prontuarios { get; set; }
        public DateTime DataAgendada { get; set; }
        public DateTime CriadoEm { get; set; }



        public override string ToString()
        {
            return "Agenda: " + Nome + "\t| CPF: " + Cpf + "\t| Plano: " + Plano + "\t| Medico: " + NomeMedico + "\t| Especialidade: " + Especialidade;
        }
    }
}
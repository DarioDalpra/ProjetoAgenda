using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Agenda_WPF.Model
{
    [Table("Agenda")]
    class Agenda
    {
        public Agenda() => CriadoEm = DateTime.Now;

        [Key]
        public int IdAgenda { get; set; }
        public Paciente Paciente { get; set; }
        public Paciente Cpf { get; set; }
        public String Plano { get; set; }
        public Medico Medico { get; set; }
        public Medico Especialidade { get; set; }
        public DateTime DataAgendada { get; set; }
        public string HoraAgendada { get; set; }
        public DateTime CriadoEm { get; set; }


    }
}
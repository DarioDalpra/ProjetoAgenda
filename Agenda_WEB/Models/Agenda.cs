using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WEB.Models
{
    [Table("Agenda")]
    public class Agenda : BaseModel
    {
        public int IdAgenda { get; set; }
        public Paciente Paciente { get; set; }
        public Paciente Cpf { get; set; }
        public String Plano { get; set; }
        public Medico Medico { get; set; }
        public Medico Especialidade { get; set; }

        [Display(Name = "Data do Agendamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAgendada { get; set; }
        public string HoraAgendada { get; set; }
  


    }
}
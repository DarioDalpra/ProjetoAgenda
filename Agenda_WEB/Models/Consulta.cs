using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WEB.Models
{
    [Table("Consultas")]
    public class Consulta : BaseModel
    {
        public Consulta()
        {
            Paciente = new Paciente();
            Medico = new Medico();
        }

        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }

        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }

        public DateTime DataConsulta { get; set; }
        public string HoraConsulta { get; set; }

    }
}
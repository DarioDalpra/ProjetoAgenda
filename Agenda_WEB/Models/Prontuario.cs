using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.Models
{

    [Table("Prontuarios")]
    public class Prontuario : BaseModel
    {
        public Prontuario()
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

        public string Sintomas { get; set; }
        public string Avaliacao { get; set; }
        public string Medicamento { get; set; }
        public string PlanoSaude { get; set; }
        public DateTime DataConsulta { get; set; }

        [NotMapped]
        public int ConsultaId { get; set; }
    }
}


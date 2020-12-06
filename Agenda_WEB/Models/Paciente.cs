using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WEB.Models
{
    [Table("Pacientes")]
    public class Paciente : Pessoa
    {
        [ForeignKey("PlanoSaudeId")]
        public PlanoSaude PlanoSaude { get; set; }
        public int PlanoSaudeId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WEB.Models
{
    public class Paciente : BaseModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Fone { get; set; }

        [ForeignKey("PlanoSaudeId")]
        public PlanoSaude PlanoSaude { get; set; }
        public int PlanoSaudeId { get; set; }

    }
}
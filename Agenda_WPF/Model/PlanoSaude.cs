using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WPF.Model
{
    [Table("tbPlanoSaude")]
    class PlanoSaude
    {
        [Key]
        public int PlanoSaudeId { get; set; }
        public string Plano { get; set; }


    }
}
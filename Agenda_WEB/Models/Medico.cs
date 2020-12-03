using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WEB.Models
{
    [Table("Medicos")]
    public class Medico : Pessoa
    {
        public string CRM { get; set; }
        public string Especialidade { get; set; }

    }
}

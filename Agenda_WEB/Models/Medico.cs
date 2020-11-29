using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WEB.Models
{
    [Table("Medico")]
    public class Medico : BaseModel
    {
        public string Nome { get; set; }
        public string CRM { get; set; }


    }
}
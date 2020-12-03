using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WEB.Models
{
    [Table("PlanosSaude")]
    public class PlanoSaude : BaseModel
    {
        public String Plano { get; set; }
        public String Codigo { get; set; }
    }
}


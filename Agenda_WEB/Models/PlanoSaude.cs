using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.Models
{
    [Table("PlanoSaude")]
    public class PlanoSaude : BaseModel
    {
        public String Plano { get; set; }
        public String Codigo { get; set; }
    }
}
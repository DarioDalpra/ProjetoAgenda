using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.Models
{
    [Table("Paciente")]
    public class Paciente : BaseModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Fone { get; set; }

    }
}

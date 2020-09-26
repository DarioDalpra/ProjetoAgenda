using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Agenda_WPF.Model
{
    [Table("Medicos")]
    public class Medico : Pessoa
    {
        public Medico() => CriadoEm = DateTime.Now;

        [Key]
        public int IdMedico { get; set; }
        public string Crm { get; set; }
        public string Especialidade { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
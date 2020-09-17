using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Agenda_WPF.Model
{
    [Table("Medicos")]
    class Medico
    {
        public Medico() => CriadoEm = DateTime.Now; // não funciona caso não tenha sido inserido a data.

        [Key]
        public int IdMedico { get; set; }
        public string NomeMedico { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Especialidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return "Medico: " + NomeMedico + "\t| CPF: " + Cpf + "\t| CRM: " + Crm + "\t| Especialidade: " + Especialidade;
        }
    }
}
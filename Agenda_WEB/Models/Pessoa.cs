using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.Models
{
    public class Pessoa : BaseModel
    {
        [DisplayName("Nome:")]
        public string Nome { get; set; }

        [DisplayName("CPF:")]
        public string Cpf { get; set; }

        [DisplayName("RG:")]
        public string Rg { get; set; }

        [DisplayName("Nascimento:")]
        public string Nascimento { get; set; }

        [DisplayName("Telefone:")]
        public string Telefone { get; set; }

        [DisplayName("Email:")]
        public string Email { get; set; }

        [DisplayName("CEP:")]
        public string Cep { get; set; }

        [DisplayName("Rua:")]
        public string Rua { get; set; }

        [DisplayName("Numero:")]
        public string Numero { get; set; }

        [DisplayName("Bairro:")]
        public string Bairro { get; set; }

        [DisplayName("Cidade:")]
        public string Cidade { get; set; }

        [DisplayName("UF:")]
        public string Estado { get; set; }
    }
}
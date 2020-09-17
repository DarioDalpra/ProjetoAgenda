using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_WPF.Model
{
    [Table("Usuarios")]
    class Usuario
    {
        public Usuario() => CriadoEm = DateTime.Now;
        [Key]
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Administrador { get; set; }
        public bool Medico { get; set; }
        public bool Atendente { get; set; }

        public DateTime CriadoEm { get; set; }


        public override string ToString()
        {
            return $"Nome: {Nome} | Cpf: {Cpf} | Email: {Email} | Adm: {Administrador} | Médico: {Medico} | Atendente: {Atendente} | Criado em: {CriadoEm}.";
        }
    }
}
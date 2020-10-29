using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Médico")]
        [Required(ErrorMessage = "É necessário informar o médico")]
        public Guid MedicoId { get; set; }

        [DisplayName("Paciente")]
        [Required(ErrorMessage = "É necessário informar o paciente")]
        public Guid PacienteId { get; set; }

        [DisplayName("Início")]
        [Required(ErrorMessage = "É necessário informar o horário de início")]
        public DateTime InicioAtendimento { get; set; }

        [DisplayName("Término")]
        [Required(ErrorMessage = "É necessário informar o horário de término")]
        public DateTime FimAtendimento { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }

        [NotMapped]
        public IEnumerable<Paciente> Pacientes { get; set; }
        [NotMapped]
        public IEnumerable<Medico> Medicos { get; set; }
    }
}
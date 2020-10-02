using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Agenda_WPF.Model
{
    [Table("Prontuarios")]
    class Prontuario
    {
        public Prontuario() => DataConsulta = DateTime.Now;

        [Key]
        public int IdProntuario { get; set; }
        public virtual Paciente NomePaciente { get; set; }
        public virtual Medico NomeMedico { get; set; }
        public string Sintomas { get; set; }
        public string Avaliacao { get; set; }
        public string Medicamento { get; set; }
        public string PlanoSaude { get; set; }
        public DateTime DataConsulta { get; set; }

        public override string ToString()
        {
            return $"Paciente: {NomePaciente} | Médico: {NomeMedico} | Sintomas: {Sintomas} | Avaliação: {Avaliacao} | " +
                   $"Medicamento: {Medicamento} | Plano de Saúde: {PlanoSaude} | Data da Consulta: {DataConsulta}.";
        }
    }
}
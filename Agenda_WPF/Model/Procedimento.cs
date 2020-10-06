using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Agenda_WPF.Model
{
    [Table("tbProcedimentos")]
    class Procedimento
    {
        [Key]
        public int ProcedimentoId { get; set; }
        public string NomeProcedimento { get; set; }
        public double Valor { get; set; }

    }
}
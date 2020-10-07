using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agenda_WPF.Model;
using Microsoft.EntityFrameworkCore;

namespace Agenda_WPF.DAL
{
    class AgendaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Agenda> ListarAgendas()
            => ctx.Agendas.ToList();
        public static Agenda BuscarPacientePorId(int id)
            => ctx.Agendas.Find(id);
        public static Agenda BuscarAgendaPorNome(Agenda a)
            => ctx.Agendas.FirstOrDefault(x => x.Paciente.Equals(a.Paciente));
        public static Agenda BuscarAgendaPorData(Agenda a)
            => ctx.Agendas.FirstOrDefault(x => x.DataAgendada.Equals(a.DataAgendada) &&
                 x.HoraAgendada.Equals(a.HoraAgendada) && x.Paciente.Equals(a.Paciente));
        public static List<Agenda> BuscarListagemPorMedico(int idMedico)
            => ctx.Agendas.Where(x => x.Medico.IdMedico == idMedico).Include(x => x.Paciente).Include(x => x.Medico).ToList();
        public static string CadastrarAgenda(Agenda a)
        {
            if (BuscarAgendaPorData(a) == null)
            {
                ctx.Agendas.Add(a);
                ctx.SaveChanges();
                return null;
            }
            return "Horário já agendado";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agenda_WPF.DAL;
using Agenda_WPF.Model;

namespace Agenda_WPF.DAL
{
    class AgendaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

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

        public static Agenda BuscarAgendaPorNome(Agenda a)
        {
            return ctx.Agendas.FirstOrDefault(x => x.Paciente.Equals(a.Paciente));
        }

        public static Agenda BuscarAgendaPorData(Agenda a)
        {
            return ctx.Agendas.FirstOrDefault(x => x.DataAgendada.Equals(a.DataAgendada) &&
                                              x.HoraAgendada.Equals(a.HoraAgendada) &&
                                              x.Paciente.Equals(a.Paciente));
        }

        public static Agenda BuscarPacientePorId(int id)
        {
            return ctx.Agendas.Find(id);
        }

        public static List<Agenda> ListarAgendas()
        {
            //return ctx.Produtos.FirstOrDefault( x => x.ProdutoId == id);    
            return ctx.Agendas.ToList();
        }
    }
}
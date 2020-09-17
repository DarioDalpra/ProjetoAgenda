using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agenda_WPF.Model;


    namespace Agenda_WPF.DAL
    {
        class AgendaDAO
        {
            private static Context ctx = new Context();

            public static bool CadastrarAgenda(Agenda a)
            {
                if (BuscarAgendaPorNome(a) == null)
                {
                    ctx.Agendas.Add(a);
                    ctx.SaveChanges();
                    return true;
                }
                return false;


            }

            public static Agenda BuscarAgendaPorNome(Agenda a)
            {
                return ctx.Agendas.FirstOrDefault(x => x.Nome.Equals(a.Nome));
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
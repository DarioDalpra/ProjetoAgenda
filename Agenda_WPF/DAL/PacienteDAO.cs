using Agenda_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda_WPF.DAL
{
    class PacienteDAO
    {
        private static Context ctx = new Context();

        public static bool CadastrarPaciente(Paciente p)
        {
            if (BuscarPacientePorNome(p) == null)
            {
                ctx.Pacientes.Add(p);
                ctx.SaveChanges();
                return true;
            }
            return false;


        }

        public static Paciente BuscarPacientePorNome(Paciente p)
        {
            return ctx.Pacientes.FirstOrDefault(x => x.Nome.Equals(p.Nome));
        }


        public static Paciente BuscarPacientePorId(int id)
        {
            return ctx.Pacientes.Find(id);
        }

        public static List<Paciente> ListarPacientes()
        {
            //return ctx.Produtos.FirstOrDefault( x => x.ProdutoId == id);    
            return ctx.Pacientes.ToList();
        }
    }
}

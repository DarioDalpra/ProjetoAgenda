using Agenda_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda_WPF.DAL
{
    class MedicoDAO
    {
        private static Context ctx = new Context();

        public static bool CadastrarMedico(Medico m)
        {
            if (BuscarMedicoPorNome(m) == null)
            {
                ctx.Medicos.Add(m);
                ctx.SaveChanges();
                return true;
            }
            return false;


        }

        public static Medico BuscarMedicoPorNome(Medico m)
        {
            return ctx.Medicos.FirstOrDefault(x => x.NomeMedico.Equals(m.NomeMedico));
        }


        public static Medico BuscarMedicoPorId(int id)
        {
            return ctx.Medicos.Find(id);
        }

        public static List<Medico> ListarMedicos()
        {
            //return ctx.Produtos.FirstOrDefault( x => x.ProdutoId == id);    
            return ctx.Medicos.ToList();
        }
    }
}
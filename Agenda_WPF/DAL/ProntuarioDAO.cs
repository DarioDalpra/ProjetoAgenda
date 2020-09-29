using Agenda_WPF.Model;
using System.Collections.Generic;
using System.Linq;

namespace Agenda_WPF.DAL
{
    class ProntuarioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarProntuario(Prontuario prontuario)
        {
            if (BuscarProntuarioPorNome(prontuario.NomePaciente) == null)
            {
                ctx.Prontuarios.Add(prontuario);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Prontuario BuscarProntuarioPorId(int id) => ctx.Prontuarios.Find(id);
        
        public static Paciente BuscarProntuarioPorNome(Paciente p) => ctx.Pacientes.FirstOrDefault(x => x.Nome.Equals(p.Nome));
        public static List<Prontuario> ListarProntuario() => ctx.Prontuarios.ToList();

        public static void AlterarPaciente(Paciente p)
        {
            ctx.Pacientes.Update(p);
            ctx.SaveChanges();
        }

    }
}
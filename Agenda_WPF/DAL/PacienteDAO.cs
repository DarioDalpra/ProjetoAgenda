using Agenda_WPF.Model;
using System.Collections.Generic;
using System.Linq;

namespace Agenda_WPF.DAL
{
   class PacienteDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

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

        public static Paciente BuscarPacientePorId(int id) => ctx.Pacientes.Find(id);
        public static Paciente BuscarPacientePorCpf(Paciente p) => ctx.Pacientes.FirstOrDefault(x => x.Cpf.Equals(p.Cpf));
        public static Paciente BuscarPacientePorNome(Paciente p) => ctx.Pacientes.FirstOrDefault(x => x.Nome.Equals(p.Nome));


        public static List<Paciente> ListarPacientes() => ctx.Pacientes.ToList();

    }
}
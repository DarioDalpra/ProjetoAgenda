using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agenda_WPF.Model;

namespace Agenda_WPF.DAL
{
    class Usuario
    {
        private static Context ctx = SingletonContext.GetInstance();
        private static List<Usuario> usuarios = new List<Usuario>();

        public static bool CadastrarUsuario(Usuario u)
        {
            if (BuscarUsuarioPorTipo(u.TipoUsuario) == null)
            {
                ctx.Usuarios.Add(u);
                ctx.SaveChanges();
                return true;
            }
            return false;


        }

        public static Usuario BuscarUsuarioPorTipo(string u)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.TipoUsuario.Equals(u));
        }

        public static Usuario BuscarUsuarioPorId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public static List<Paciente> ListarPacientes()
        {
            return ctx.Pacientes.ToList();
        }


    }
}
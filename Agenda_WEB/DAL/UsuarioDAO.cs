using Agenda_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.DAL
{
    public class UsuarioDAO
    {
        private readonly Context _context;

        public UsuarioDAO(Context context) => _context = context;

        public List<UsuarioView> Listar() => _context.Usuarios.ToList();

        public UsuarioView BuscarPorId(int id) => _context.Usuarios
            .FirstOrDefault(x => x.Id == id);

        public UsuarioView BuscarPorNome(string nome) => _context.Usuarios
            .FirstOrDefault(x => x.Nome == nome);





        public void Editar(UsuarioView usuarioView)
        {
            _context.Usuarios.Update(usuarioView);
            _context.SaveChanges();
        }
    }
}
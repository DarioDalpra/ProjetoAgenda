using Agenda_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.DAL
{
    public class MedicoDAO
    {
        private readonly Context _context;
        public MedicoDAO(Context context) => _context = context;
        public List<Medico> Listar() => _context.Medicos.ToList();
        public Medico BuscarPorId(int id) => _context.Medicos.Find(id);
    }
}
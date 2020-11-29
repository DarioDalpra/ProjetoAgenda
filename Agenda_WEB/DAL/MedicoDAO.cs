using Agenda_WEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace Agenda_WEB.DAL
{
    public class MedicoDAO
    {
        private readonly Context _context;
        public MedicoDAO(Context context) => _context = context;
        public List<Medico> Listar() => _context.Medicos.ToList();

        public Medico BuscarPorId(int id) => _context.Medicos.Find(id);

        public Medico BuscarPorNome(string nome) =>
            _context.Medicos.FirstOrDefault(x => x.Nome == nome);

        public bool Cadastrar(Paciente paciente)
        {
            if (BuscarPorNome(paciente.Nome) == null)
            {
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Remover(int id)
        {
            _context.Medicos.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Medico medico)
        {
            _context.Medicos.Update(medico);
            _context.SaveChanges();
        }
    }
}
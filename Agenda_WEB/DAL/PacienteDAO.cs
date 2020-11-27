using Agenda_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.DAL
{
    public class PacienteDAO
    {
        private readonly Context _context;
        public PacienteDAO(Context context) => _context = context;
        public List<Paciente> Listar() =>
            _context.Pacientes.ToList();
        public Paciente BuscarPorId(int id) => _context.Pacientes.Find(id);
        public Paciente BuscarPorNome(string nome) =>
            _context.Pacientes.FirstOrDefault(x => x.Nome == nome);

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
            _context.Pacientes.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }
    }
}
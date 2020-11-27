using Agenda_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.DAL
{
    public class ConsultaDAO
    {
        private readonly Context _context;
        public ConsultaDAO(Context context) => _context = context;
        public List<Consulta> Listar() =>
            _context.Consultas.ToList();
        public Consulta BuscarPorId(int id) => _context.Consultas.Find(id);
        public Consulta BuscarPorPacienteMedicoHora(int PacienteId, int MedicoId, DateTime Hora) =>
            _context.Consultas.FirstOrDefault(x => x.PacienteId == PacienteId &&
                                              x.MedicoId == MedicoId && x.HoraConsulta == Hora);

        public List<Consulta> ListarPorMedico(int id) =>
            _context.Consultas.Where(x => x.MedicoId == id).ToList();

        public bool Cadastrar(Consulta consulta)
        {
            if (BuscarPorPacienteMedicoHora(consulta.PacienteId, consulta.MedicoId, consulta.HoraConsulta) == null)
            {
                _context.Consultas.Add(consulta);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Remover(int id)
        {
            _context.Consultas.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Consulta consulta)
        {
            _context.Consultas.Update(consulta);
            _context.SaveChanges();
        }
    }
}
using Agenda_WEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda_WEB.DAL
{
    public class ConsultaDAO
    {
        private readonly Context _context;

        public ConsultaDAO(Context context) => _context = context;

        public List<Consulta> Listar() => _context.Consultas.ToList();

        public Consulta BuscarPorId(int id) => _context.Consultas.Include(x => x.Paciente).FirstOrDefault(x => x.Id == id);

        public Consulta BuscarPorPacienteMedicoHora(int PacienteId, int MedicoId, string Hora) =>
            _context.Consultas.FirstOrDefault(x => x.PacienteId == PacienteId &&
                                              x.MedicoId == MedicoId && x.HoraConsulta == Hora);

        public List<Consulta> ListarPorMedico(int id) =>
            _context.Consultas.Where(x => x.MedicoId == id).ToList();

        public string Cadastrar(Consulta consulta)
        {
            if (BuscarPorPacienteMedicoHora(consulta.PacienteId, consulta.MedicoId,
                                            consulta.HoraConsulta) == null)
            {
                _context.Consultas.Add(consulta);
                _context.SaveChanges();
                return "";
            }
            return "Horário indisponível";
        }
        public void Remover(int id)
        {
            _context.Consultas.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public string Alterar(Consulta consulta)
        {
            if (BuscarPorPacienteMedicoHora(consulta.PacienteId, consulta.MedicoId,
                                               consulta.HoraConsulta) == null)
            {
                _context.Consultas.Update(consulta);
                _context.SaveChanges();
                return "";
            }
            return "Horário indisponível";
        }
    }
}
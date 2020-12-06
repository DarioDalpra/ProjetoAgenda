using Agenda_WEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.DAL
{
    public class ProntuarioDAO
    {
        private readonly Context _context;

        public ProntuarioDAO(Context context) => _context = context;

        public List<Prontuario> Listar() => _context.Prontuarios.ToList();

        public Prontuario BuscarPorId(int id) => _context.Prontuarios
            .Include(x => x.Paciente)
            .Include(x => x.Medico)
            .FirstOrDefault(x => x.Id == id);


        public int Cadastrar(Prontuario prontuario)
        {
            _context.Prontuarios.Add(prontuario);
            _context.SaveChanges();
            return prontuario.Id;

        }


    }
}
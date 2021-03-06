﻿using Agenda_WPF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Agenda_WPF.DAL
{
    class MedicoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static bool CadastrarMedico(Medico m)
        {
            if (BuscarMedicoPorNome(m) == null)
            {
                ctx.Medicos.Add(m);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Medico BuscarMedicoPorId(int id) => ctx.Medicos.Find(id);
        public static Medico BuscarMedicoPorNome(Medico m) => ctx.Medicos.FirstOrDefault(x => x.Nome.Equals(m.Nome));
        public static Medico BuscarMedicoPorCpf(Medico m) => ctx.Medicos.FirstOrDefault(x => x.Cpf.Equals(m.Cpf));
        public static Medico BuscarMedicoPorCrm(Medico m) => ctx.Medicos.FirstOrDefault(x => x.Crm.Equals(m.Crm));
        public static List<Medico> ListarMedicos() => ctx.Medicos.ToList();

        public static void AlterarMedico(Medico m)
        {
            ctx.Medicos.Update(m);
            ctx.SaveChanges();
        }

        public static void Remover(Medico m)
        {
            ctx.Agendas.RemoveRange(ctx.Agendas.Where(x => x.Medico.IdMedico.Equals(m.IdMedico)));
            ctx.Prontuarios.RemoveRange(ctx.Prontuarios.Where(x => x.NomeMedico.IdMedico.Equals(m.IdMedico)));
            ctx.Entry(m).State = EntityState.Deleted;
            ctx.SaveChanges();
        }
    }
}
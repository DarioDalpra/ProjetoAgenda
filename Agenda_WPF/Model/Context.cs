using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agenda_WPF.Model
{

    class Context : DbContext
    {
       
        
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
                                           Database=PessoasDb;
                                            Trusted_Connection=true");
        }
    }
    }
  





     


    


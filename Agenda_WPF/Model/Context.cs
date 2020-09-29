
using Microsoft.EntityFrameworkCore;

namespace Agenda_WPF.Model
{

    class Context : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Prontuario> Prontuários { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
                                          Database=AgendaWPFDb;
                                          Trusted_Connection=true");
        }
    }
}







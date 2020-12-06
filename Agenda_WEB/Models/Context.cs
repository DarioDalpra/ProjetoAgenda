using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agenda_WEB.Models
{
    public class Context : IdentityDbContext<Usuario>
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<PlanoSaude> PlanosSaude { get; set; }
        public DbSet<UsuarioView> Usuarios { get; set; }
        public DbSet<Prontuario> Prontuarios { get; set; }

    }
}

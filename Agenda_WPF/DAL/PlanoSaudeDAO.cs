using Agenda_WPF.Model;
using System.Collections.Generic;
using System.Linq;


namespace Agenda_WPF.DAL
{
    class PlanoSaudeDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<PlanoSaude> ListarPlanoSaude() => ctx.PlanosSaude.ToList();
        public static PlanoSaude BuscarPlanoSaudePorId(int id) => ctx.PlanosSaude.Find(id);
        public static PlanoSaude BuscarPlanoSaudePorNome(PlanoSaude ps)
                                 => ctx.PlanosSaude.FirstOrDefault(x => x.Plano.Equals(ps.Plano));

        public static bool CadastrarPlanoSaude(PlanoSaude ps)
        {
            if (BuscarPlanoSaudePorNome(ps) == null)
            {
                ctx.PlanosSaude.Add(ps);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
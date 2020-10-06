using Agenda_WPF.Model;
using System.Linq;


namespace Agenda_WPF.DAL
{
    class ProcedimentoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static Procedimento BuscarPorNome(string nome) =>
            ctx.Procedimentos.FirstOrDefault(x => x.NomeProcedimento == nome);
        public static bool Cadastrar(Procedimento procedimento)
        {
            if (BuscarPorNome(procedimento.NomeProcedimento) == null)
            {
                ctx.Procedimentos.Add(procedimento);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
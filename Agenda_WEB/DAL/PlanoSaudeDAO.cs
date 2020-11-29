using Agenda_WEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace Agenda_WEB.DAL
{
    public class PlanoSaudeDAO
    {
        private readonly Context _context;
        public PlanoSaudeDAO(Context context) => _context = context;
        public List<PlanoSaude> Listar() => _context.PlanosSaude.ToList();
        public PlanoSaude BuscarPorId(int id) => _context.PlanosSaude.Find(id);

        public PlanoSaude BuscarPorNome(string nome) =>
           _context.PlanosSaude.FirstOrDefault(x => x.Plano == nome);

        public bool Cadastrar(PlanoSaude planoSaude)
        {
            if (BuscarPorNome(planoSaude.Plano) == null)
            {
                _context.PlanosSaude.Add(planoSaude);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Remover(int id)
        {
            _context.PlanosSaude.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(PlanoSaude planoSaude)
        {
            _context.PlanosSaude.Update(planoSaude);
            _context.SaveChanges();
        }
    }
}

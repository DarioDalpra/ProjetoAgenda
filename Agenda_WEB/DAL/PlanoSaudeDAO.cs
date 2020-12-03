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

        public PlanoSaude BuscarPorNome(string planosaude) =>
            _context.PlanosSaude.FirstOrDefault(x => x.Plano == planosaude);

        public bool Cadastrar(PlanoSaude planosaude)
        {
            if (BuscarPorNome(planosaude.Plano) == null)
            {
                _context.PlanosSaude.Add(planosaude);
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
        public void Alterar(PlanoSaude planosaude)
        {
            _context.PlanosSaude.Update(planosaude);
            _context.SaveChanges();
        }
    }
}
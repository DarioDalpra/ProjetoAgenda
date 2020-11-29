using Agenda_WEB.DAL;
using Agenda_WEB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_WEB.Controllers
{
    public class PlanoSaudeController : Controller
    {
        
        private readonly PlanoSaudeDAO _planosaudeDAO;
        private readonly IWebHostEnvironment _hosting;
        public PlanoSaudeController(PlanoSaudeDAO planosaudeDAO, IWebHostEnvironment hosting)
        {
            _planosaudeDAO = planosaudeDAO;

            _hosting = hosting;
        }
        public IActionResult Index()
        {

            ViewBag.Title = "Gerenciamento de Plano de Saúde";
            return View(_planosaudeDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            ViewBag.Title = "Cadastrar Plano de Saúde";
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(PlanoSaude planoSaude)
        {
            if (ModelState.IsValid)
            {

            }


            return View(planoSaude);
        }

        public IActionResult Remover(int id)
        {
            _planosaudeDAO.Remover(id);
            return RedirectToAction("Index", "PlanoSaude");
        }
        public IActionResult Alterar(int id)
        {
            return View(_planosaudeDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(PlanoSaude planoSaude)
        {
            _planosaudeDAO.Alterar(planoSaude);
            return RedirectToAction("Index", "PlanoSaude");
        }
    }
}

using Agenda_WEB.DAL;
using Agenda_WEB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_WEB.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MedicoDAO _medicoDAO;
        private readonly IWebHostEnvironment _hosting;
        public MedicoController(MedicoDAO medicoDAO, IWebHostEnvironment hosting)
        {
            _medicoDAO = medicoDAO;
            _hosting = hosting;
        }
        public IActionResult Index()
        {

            ViewBag.Title = "Gerenciamento de Medico";
            return View(_medicoDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            ViewBag.Title = "Cadastrar Medico";
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            if (ModelState.IsValid)
            {

            }


            return View(medico);
        }

        public IActionResult Remover(int id)
        {
            _medicoDAO.Remover(id);
            return RedirectToAction("Index", "Medico");
        }
        public IActionResult Alterar(int id)
        {
            return View(_medicoDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Medico medico)
        {
            _medicoDAO.Alterar(medico);
            return RedirectToAction("Index", "Medico");
        }
    }
}

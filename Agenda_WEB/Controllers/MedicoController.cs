using Agenda_WEB.DAL;
using Agenda_WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agenda_WEB.Controllers
{
    [Authorize]
    public class MedicoController : Controller
    {
        private readonly MedicoDAO _medicoDAO;
        //private readonly PlanoSaudeDAO _planosaudeDAO;
        private readonly IWebHostEnvironment _hosting;
        public MedicoController(MedicoDAO medicoDAO,
                                 IWebHostEnvironment hosting)
        {
            _medicoDAO = medicoDAO;
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Médicos";
            return View(_medicoDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            ViewBag.Medicos = new SelectList(_medicoDAO.Listar(), "Id", "Nome", "CRM");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Medico medico, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (_medicoDAO.Cadastrar(medico))
                {
                    return RedirectToAction("Index", "Medico");
                }
                ModelState.AddModelError("", "Já existe um Médico com o mesmo nome!");
            }
            ViewBag.medicos = new SelectList(_medicoDAO.Listar(), "Id", "Nome", "CRM");
            return View(medico);
        }
        public IActionResult Remover(int id)
        {
            _medicoDAO.Remover(id);
            return RedirectToAction("Index", "Medico");
        }
        public IActionResult Alterar(int id)
        {
            ViewBag.Medicos = new SelectList(_medicoDAO.Listar(), "Id", "Nome", "CRM");
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
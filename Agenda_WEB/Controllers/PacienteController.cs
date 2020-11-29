using Agenda_WEB.DAL;
using Agenda_WEB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agenda_WEB.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteDAO _pacienteDAO;
        private readonly PlanoSaudeDAO _planosaudeDAO;
        private readonly IWebHostEnvironment _hosting;
        public PacienteController(PacienteDAO pacienteDAO,
            IWebHostEnvironment hosting,
            PlanoSaudeDAO planosaudeDAO)
        {
            _pacienteDAO = pacienteDAO;
            _planosaudeDAO = planosaudeDAO;
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Pacientes";
            return View(_pacienteDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            ViewBag.PlanosSaude = new SelectList(_planosaudeDAO.Listar(), "Id", "Plano", "Codigo");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //if (file != null)
                //{
                //    string arquivo = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                //    string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);
                //    file.CopyTo(new FileStream(caminho, FileMode.CreateNew));
                //    paciente.Imagem = arquivo;
                //}
                //else
                //{
                //    paciente.Imagem = "semimagem.gif";
                //}
                paciente.PlanoSaude = _planosaudeDAO.BuscarPorId(paciente.PlanoSaudeId);
                if (_pacienteDAO.Cadastrar(paciente))
                {
                    return RedirectToAction("Index", "Paciente");
                }
                ModelState.AddModelError("", "Já existe um paciente com o mesmo nome!");
            }
            ViewBag.PlanosSaude = new SelectList(_planosaudeDAO.Listar(), "Id", "Plano", "Codigo");
            return View(paciente);
        }
        public IActionResult Remover(int id)
        {
            _pacienteDAO.Remover(id);
            return RedirectToAction("Index", "Paciente");
        }
        public IActionResult Alterar(int id)
        {
            ViewBag.PlanosSaude = new SelectList(_planosaudeDAO.Listar(), "Id", "Plano", "Codigo");
            return View(_pacienteDAO.BuscarPorId(id));
        }
        [HttpPost]
        public IActionResult Alterar(Paciente paciente)
        {
            _pacienteDAO.Alterar(paciente);
            return RedirectToAction("Index", "Paciente");
        }
    }
}
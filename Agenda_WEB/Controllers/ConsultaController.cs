using Agenda_WEB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agenda_WEB.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IWebHostEnvironment _hosting;

        public ConsultaController(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Data: " + consulta.HoraConsulta);
                //paciente.PlanoSaude = _planosaudeDAO.BuscarPorId(paciente.PlanoSaudeId);
                //if (_pacienteDAO.Cadastrar(paciente))
                //{
                //    return RedirectToAction("Index", "Paciente");
                //}
                //ModelState.AddModelError("", "Já existe um paciente com o mesmo nome!");
            }
            //ViewBag.PlanosSaude = new SelectList(_planosaudeDAO.Listar(), "Id", "Plano", "Codigo");
            return View(consulta);
        }
    }
}
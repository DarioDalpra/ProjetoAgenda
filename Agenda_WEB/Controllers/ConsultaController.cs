using Agenda_WEB.DAL;
using Agenda_WEB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Agenda_WEB.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly PacienteDAO _pacienteDAO;
        private readonly MedicoDAO _medicoDAO;
        private readonly ConsultaDAO _consultaDAO;
        private readonly IWebHostEnvironment _hosting;

        public ConsultaController(IWebHostEnvironment hosting, PacienteDAO pacienteDAO,
                                    MedicoDAO medicoDAO, ConsultaDAO consultaDAO)
        {
            _hosting = hosting;
            _pacienteDAO = pacienteDAO;
            _medicoDAO = medicoDAO;
            _consultaDAO = consultaDAO;
        }
        public IActionResult Index(int p)
        {
            var paciente = _pacienteDAO.BuscarPorId(p);
            ViewBag.PacienteId = paciente.Id;
            ViewBag.PacienteNome = paciente.Nome;
            ViewBag.Medicos = new SelectList(_medicoDAO.Listar(), "Id", "Nome");
            ViewBag.msgSucesso = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(Consulta consulta)
        {
            if (ModelState.IsValid)
            {

                var paciente = _pacienteDAO.BuscarPorId(consulta.Id);
                consulta.Paciente = paciente;


                string resposta = _consultaDAO.Cadastrar(consulta);

                if (resposta.Length > 0)
                {
                    ModelState.AddModelError("", resposta);
                }
                else
                {
                    ViewBag.msgSucesso = "Consulta agendada!";
                }



                //Debug.WriteLine("Data: " + consulta.HoraConsulta);
                //paciente.PlanoSaude = _planosaudeDAO.BuscarPorId(paciente.PlanoSaudeId);
                //if (_pacienteDAO.Cadastrar(paciente))
                //{
                //    return RedirectToAction("Index", "Paciente");
                //}
                //ModelState.AddModelError("", "Já existe um paciente com o mesmo nome!");
            }
            //ViewBag.PlanosSaude = new SelectList(_planosaudeDAO.Listar(), "Id", "Plano", "Codigo");
            return View();
        }
    }
}
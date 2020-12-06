using Agenda_WEB.DAL;
using Agenda_WEB.Models;
using Agenda_WEB.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Agenda_WEB.Controllers
{
    public class ReceituarioController : Controller
    {
        private readonly PacienteDAO _pacienteDAO;
        private readonly MedicoDAO _medicoDAO;
        private readonly ConsultaDAO _consultaDAO;
        private readonly ProntuarioDAO _prontuarioDAO;
        private readonly IWebHostEnvironment _hosting;

        private readonly IEmailSender _emailSender;

        public ReceituarioController(IWebHostEnvironment hosting, PacienteDAO pacienteDAO,
                                    MedicoDAO medicoDAO, ConsultaDAO consultaDAO, ProntuarioDAO prontuarioDAO, IEmailSender emailSender)
        {
            _hosting = hosting;
            _pacienteDAO = pacienteDAO;
            _medicoDAO = medicoDAO;
            _consultaDAO = consultaDAO;
            _prontuarioDAO = prontuarioDAO;
            _emailSender = emailSender;
        }

        public IActionResult Index(int p)
        {
            if (p != 0)
            {
                var prontuario = _prontuarioDAO.BuscarPorId(p);
                var paciente = _pacienteDAO.BuscarPorId(prontuario.PacienteId);
                var medico = _medicoDAO.BuscarPorId(prontuario.MedicoId);
                ViewBag.DtaConsulta = prontuario.DataConsulta.ToString("dd/MM/yyyy");
                ViewBag.PacienteId = paciente.Id;
                ViewBag.PacienteNome = paciente.Nome;

                return View(prontuario);

            }
            return RedirectToAction("Index", "Consulta");
        }
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

    }
}
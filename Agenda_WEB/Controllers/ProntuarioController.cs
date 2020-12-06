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

    public class ProntuarioController : Controller
    {
        private readonly PacienteDAO _pacienteDAO;
        private readonly MedicoDAO _medicoDAO;
        private readonly ConsultaDAO _consultaDAO;
        private readonly ProntuarioDAO _prontuarioDAO;
        private readonly IWebHostEnvironment _hosting;

        private readonly IEmailSender _emailSender;

        public ProntuarioController(IWebHostEnvironment hosting, PacienteDAO pacienteDAO,
                                    MedicoDAO medicoDAO, ConsultaDAO consultaDAO, ProntuarioDAO prontuarioDAO, IEmailSender emailSender)
        {
            _hosting = hosting;
            _pacienteDAO = pacienteDAO;
            _medicoDAO = medicoDAO;
            _consultaDAO = consultaDAO;
            _prontuarioDAO = prontuarioDAO;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar(int p)
        {
            if (p != 0)
            {
                var consulta = _consultaDAO.BuscarPorId(p);
                var paciente = _pacienteDAO.BuscarPorId(consulta.PacienteId);
                var medico = _medicoDAO.BuscarPorId(consulta.MedicoId);
                ViewBag.DtaConsulta = consulta.DataConsulta.ToString("dd/MM/yyyy");
                ViewBag.HraConsulta = consulta.HoraConsulta;
                ViewBag.PacienteId = paciente.Id;
                ViewBag.PacienteNome = paciente.Nome;
                ViewBag.MedicoId = medico.Id;
                ViewBag.MedicoNome = medico.Nome;
                ViewBag.ConsultaId = p;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Consulta");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                Consulta consulta = _consultaDAO.BuscarPorId(prontuario.ConsultaId);
                var paciente = _pacienteDAO.BuscarPorId(prontuario.PacienteId);
                prontuario.Paciente = paciente;
                var medico = _medicoDAO.BuscarPorId(prontuario.MedicoId);
                prontuario.Medico = medico;
                prontuario.DataConsulta = consulta.DataConsulta;

                int resposta = _prontuarioDAO.Cadastrar(prontuario);

                if (resposta == 0)
                {
                    ModelState.AddModelError("", "Ocorreu um erro!!");
                }
                else
                {
                    ViewBag.msgSucesso = "Prontuario concluído!";
                    ViewBag.ProntuarioId = resposta;

                }

            }
            return View();
        }

        public IActionResult Alterar(int id)
        {
            if (id != 0)
            {
                var consulta = _consultaDAO.BuscarPorId(id);
                ViewBag.DataConsulta = consulta.DataConsulta.ToString("dd/MM/yyyy");
                ViewBag.HoraConsulta = consulta.HoraConsulta;
                ViewBag.PacienteNome = consulta.Paciente.Nome;
                ViewBag.PacienteId = consulta.PacienteId;
                ViewBag.Horas = new SelectList(new List<string>(new string[]
                {"09:00", "09:20", "09:40", "10:00", "10:20"}
                ), consulta.HoraConsulta.Trim());
                //ViewBag.DtaConsulta = consulta.DataConsulta;
                //ViewBag.HraConsulta = consulta.HoraConsulta;
                //ViewBag.PacienteId = consulta.PacienteId;
                //ViewBag.PacienteNome = consulta.Paciente.Nome;
                ViewBag.Medicos = new SelectList(_medicoDAO.Listar(), "Id", "Nome");
                //ViewBag.MedicoId = consulta.MedicoId;

                return View(consulta);
            }
            else
            {
                return RedirectToAction("Index", "Paciente");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                var paciente = _pacienteDAO.BuscarPorId(consulta.PacienteId);
                consulta.Paciente = paciente;
                var medico = _medicoDAO.BuscarPorId(consulta.MedicoId);
                consulta.Medico = medico;

                string resposta = _consultaDAO.Alterar(consulta);

                if (resposta.Length > 0)
                {
                    ModelState.AddModelError("", resposta);
                }
                else
                {
                    var data = consulta.DataConsulta.ToString("dd/MM/yyyy");
                    var emails = new List<string>();
                    string message = "Olá sr(a). " + paciente.Nome + ", sua consulta foi reagendada para dia " + data + " ás " + consulta.HoraConsulta + " !";
                    string assunto = "Re-Confirmação de Consulta !";
                    EmailModel novoEmail = new EmailModel() { Email = paciente.Email, Message = message, Subject = assunto };
                    emails.Add(novoEmail.Email);
                    await _emailSender.SendEmailAsync(emails, novoEmail.Subject, novoEmail.Message);

                    ViewBag.msgSucesso = "Reagendadamento concluído!";
                }

            }
            return RedirectToAction("Index", "Consulta");
        }

        public IActionResult CriarReceituario(int id)
        {
            Prontuario prontuario = _prontuarioDAO.BuscarPorId(id);

            return RedirectToAction("Receituario", new { prontuario });
        }

        [HttpGet]
        public IActionResult Receituario(Prontuario prontuario)
        {
            ViewBag.Title = "Receituário";
            return RedirectToAction("Index", "Receituario", new { p = prontuario.Id });
        }

    }
}
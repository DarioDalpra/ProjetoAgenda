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
    public class ConsultaController : Controller
    {
        private readonly PacienteDAO _pacienteDAO;
        private readonly MedicoDAO _medicoDAO;
        private readonly ConsultaDAO _consultaDAO;
        private readonly IWebHostEnvironment _hosting;

        private readonly IEmailSender _emailSender;

        public ConsultaController(IWebHostEnvironment hosting, PacienteDAO pacienteDAO,
                                    MedicoDAO medicoDAO, ConsultaDAO consultaDAO, IEmailSender emailSender)
        {
            _hosting = hosting;
            _pacienteDAO = pacienteDAO;
            _medicoDAO = medicoDAO;
            _consultaDAO = consultaDAO;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            //List<Consulta> consultas = _consultaDAO.Listar();
            ViewBag.Medicos = new SelectList(_medicoDAO.Listar(), "Id", "Nome");
            ViewBag.Consultas = new List<Consulta>();
            ViewBag.Count = 0;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Medico medico)
        {
            if (ModelState.IsValid)
            {
                if (medico.Id != 0)
                {
                    List<Consulta> consultas = _consultaDAO.ListarPorMedico(medico.Id);
                    ViewBag.Consultas = consultas;
                    ViewBag.Count = consultas.Count;
                    ViewBag.Medicos = new SelectList(_medicoDAO.Listar(), "Id", "Nome");
                }
            }
            return View();
        }

        public IActionResult Agendar(int p)
        {
            if (p != 0)
            {
                var paciente = _pacienteDAO.BuscarPorId(p);
                ViewBag.PacienteId = paciente.Id;
                ViewBag.PacienteNome = paciente.Nome;
                ViewBag.Medicos = new SelectList(_medicoDAO.Listar(), "Id", "Nome");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Paciente");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Agendar(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                var paciente = _pacienteDAO.BuscarPorId(consulta.PacienteId);
                consulta.Paciente = paciente;
                var medico = _medicoDAO.BuscarPorId(consulta.MedicoId);
                consulta.Medico = medico;

                string resposta = _consultaDAO.Cadastrar(consulta);

                if (resposta.Length > 0)
                {
                    ModelState.AddModelError("", resposta);
                }
                else
                {
                    var data = consulta.DataConsulta.ToString("dd/MM/yyyy");
                    var emails = new List<string>();
                    string message = "Olá sr(a). " + paciente.Nome + ", sua consulta para dia " + data + " ás " + consulta.HoraConsulta + " foi confirmada!";
                    string assunto = "Confirmação de Consulta !";
                    EmailModel novoEmail = new EmailModel() { Email = paciente.Email, Message = message, Subject = assunto };
                    emails.Add(novoEmail.Email);
                    await _emailSender.SendEmailAsync(emails, novoEmail.Subject, novoEmail.Message);

                    ViewBag.msgSucesso = "Agendadamento concluído!";
                }

            }
            //ViewBag.PlanosSaude = new SelectList(_planosaudeDAO.Listar(), "Id", "Plano", "Codigo");
            return View();
        }

        public IActionResult Alterar(int id)
        {
            if (id != 0)
            {
                var consulta = _consultaDAO.BuscarPorId(id);
                ViewBag.DataConsulta = consulta.DataConsulta;
                ViewBag.HoraConsulta = consulta.HoraConsulta;
                ViewBag.PacienteNome = consulta.Paciente.Nome;
                ViewBag.PacienteId = consulta.PacienteId;
                ViewBag.Horas = new SelectList(new List<string>(new string[]
                {"09:00","09:20","09:40","10:00","10:20","10:40","11:00","11:20","11:40",
                 "12:00","12:20","12:40","13:00","13:20","13:40","14:00","14:20","14:40",
                 "15:00","15:20","15:40","16:00","16:20","16:40","17:00","17:20","17:40"}
                ), consulta.HoraConsulta.Trim());
                ViewBag.Medicos = new SelectList(_medicoDAO.Listar(), "Id", "Nome");


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
            //return View();
        }

        public IActionResult CriarProntuario(int id)
        {
            Consulta consulta = _consultaDAO.BuscarPorId(id);

            return RedirectToAction("Prontuario", new { consulta });
        }

        [HttpGet]
        public IActionResult Prontuario(Consulta consulta)
        {
            ViewBag.Title = "Prontuário";
            return RedirectToAction("Cadastrar", "Prontuario", new { p = consulta.Id });
        }


        //public IActionResult CriarAgendaMedica(int id)
        //{
        //    Consulta consulta = _consultaDAO.BuscarPorId(id);

        //    return RedirectToAction("AgendaMedica", new { consulta });
        //}

        //[HttpGet]
        //public IActionResult AgendaMedica(Consulta consulta)
        //{
        //    ViewBag.Title = "Agenda Médica";
        //    return RedirectToAction("Listar", "Agenda", new { p = consulta.Id });
        //}


    }
}
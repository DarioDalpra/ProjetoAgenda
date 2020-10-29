using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_WEB.Controllers
{
    [Authorize]
    [Route("agendamentos")]
    public class AgendamentosController : BaseController
    {
        private readonly IAgendamentosRepository _agendamentoRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IAgendamentoService _agendamentoService;
        private readonly IMapper _mapper;

        public AgendamentosController(IAgendamentosRepository agendamentosRepository,
                                      IMedicoRepository medicoRepository,
                                      IPacienteRepository pacienteRepository,
                                      IAgendamentoService agendamentoService,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)
        {
            _agendamentoRepository = agendamentosRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
            _agendamentoService = agendamentoService;
            _mapper = mapper;
        }

        [Route("lista-de-agendamentos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<Agendamento>>(await _agendamentoRepository.ObterAgendamentosPacientes()));
        }

        [Route("detalhes-do-agendamento")]
        public async Task<IActionResult> Details(Guid id)
        {

            var agendamentoViewModel = await ObterAgendamento(id);

            if (agendamentoViewModel == null)
            {
                return NotFound();
            }

            return View(agendamentoViewModel);
        }

        [Route("novo-agendamento")]
        public async Task<IActionResult> Create()
        {
            var agendamento = new Agendamento();

            agendamento.Pacientes = _mapper.Map<IEnumerable<Paciente>>(await _pacienteRepository.ObterTodos());
            agendamento.Medicos = _mapper.Map<IEnumerable<Medico>>(await _medicoRepository.ObterTodos());

            return View(agendamento);
        }

        [Route("novo-agendamento")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Agendamento agendamentoViewModel)
        {
            agendamentoViewModel.Pacientes = _mapper.Map<IEnumerable<Paciente>>(await _pacienteRepository.ObterTodos());
            agendamentoViewModel.Medicos = _mapper.Map<IEnumerable<Medico>>(await _medicoRepository.ObterTodos());

            if (!ModelState.IsValid) return View(agendamentoViewModel);

            await _agendamentoService.Adicionar(_mapper.Map<Agendamento>(agendamentoViewModel));
            if (!OperacaoValida()) return View(agendamentoViewModel);

            TempData["Sucesso"] = "Agendamento cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        [Route("editar-agendamento/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var agendamentoViewModel = await ObterAgendamento(id);

            if (agendamentoViewModel == null)
            {
                return NotFound();
            }
            return View(agendamentoViewModel);
        }

        [Route("editar-agendamento/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Agendamento agendamento)
        {
            if (id != agendamento.Id) return NotFound();

            var agendamentoAtualizacao = await ObterAgendamento(id);


            if (!ModelState.IsValid) return View(agendamento);

            agendamentoAtualizacao.InicioAtendimento = agendamento.InicioAtendimento;
            agendamentoAtualizacao.FimAtendimento = agendamento.FimAtendimento;
            agendamentoAtualizacao.Observacao = agendamento.Observacao;

            await _agendamentoService.Atualizar(_mapper.Map<Agendamento>(agendamentoAtualizacao));
            if (!OperacaoValida()) return View(agendamentoAtualizacao);

            return RedirectToAction("Index");


        }

        [Route("excluir-agendamento/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var agendamento = await ObterAgendamento(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        [Route("excluir-agendamento/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var agendamento = await ObterAgendamento(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            await _agendamentoService.Remover(id);
            if (!OperacaoValida()) return View(agendamento);

            TempData["Sucesso"] = "Agendamento excluído com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<Agendamento> ObterAgendamento(Guid id)
        {
            var agendamento = _mapper.Map<Agendamento>(await _agendamentoRepository.ObterAgendamentoPaciente(id));
            agendamento.Medico = _mapper.Map<Medico>(await _medicoRepository.ObterPorId(agendamento.MedicoId));

            return agendamento;
        }

    }
}

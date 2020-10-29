using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_WEB.Controllers
{
    [Authorize]
    [Route("medicos")]
    public class MedicosController : BaseController
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;

        public MedicosController(IMedicoRepository medicoRepository,
                                 IMedicoService medicoService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _medicoRepository = medicoRepository;
            _medicoService = medicoService;
            _mapper = mapper;
        }

        [Route("lista-de-medicos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<Medico>>(await _medicoRepository.ObterTodos()));
        }

        [Route("detalhes-do-medico/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var medicoViewModel = _mapper.Map<Medico>(await _medicoRepository.ObterPorId(id));
            if (medicoViewModel == null)
            {
                return NotFound();
            }

            return View(medicoViewModel);
        }

        [Route("novo-medico")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [Route("novo-medico")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Medico medicoViewModel)
        {
            if (!ModelState.IsValid) return View(medicoViewModel);

            var medico = _mapper.Map<Medico>(medicoViewModel);
            await _medicoService.Adicionar(medico);
            if (!OperacaoValida()) return View(medicoViewModel);

            TempData["Sucesso"] = "Médico cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        [Route("editar-medico/{id:guid}")]
        public async Task<IActionResult> Alterar(Guid id)
        {
            var medicoViewModel = _mapper.Map<Medico>(await _medicoRepository.ObterPorId(id));
            if (medicoViewModel == null)
            {
                return NotFound();
            }
            return View(medicoViewModel);
        }

        [Route("editar-medico/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(Guid id, Medico medico)
        {
            if (id != medico.Id) return NotFound();

            if (!ModelState.IsValid) return View(medico);

            var medico = _mapper.Map<Medico>(medico);
            await _medicoService.Atualizar(medico);
            if (!OperacaoValida()) return View(medico);

            return RedirectToAction("Index");
        }

        [Route("excluir-medico/{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {

            var medicoViewModel = _mapper.Map<Medico>(await _medicoRepository.ObterPorId(id));

            if (medicoViewModel == null) return NotFound();

            return View(medicoViewModel);
        }

        [Route("excluir-medico/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var medicoViewModel = _mapper.Map<Medico>(await _medicoRepository.ObterPorId(id));
            if (medicoViewModel == null) return NotFound();

            await _medicoService.Remover(id);
            if (!OperacaoValida()) return View(medicoViewModel);

            TempData["Sucesso"] = "Médico excluído com sucesso!";

            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_WEB.DAL;
using Agenda_WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_WEB.Controllers
{
    [Route("api/Consulta")]
    [ApiController]
    public class ConsultaAPIController : ControllerBase
    {
        private readonly ConsultaDAO _consultaDAO;
        public ConsultaAPIController(ConsultaDAO consultaDAO)
        {
            _consultaDAO = consultaDAO;
        }

        //GET: /api/Consulta/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<Consulta> consultas = _consultaDAO.Listar();
            if (consultas.Count > 0)
            {
                return Ok(consultas);
            }
            return BadRequest(new { msg = "A lista de consultas está vazia!" });
        }

        ////GET: /api/Consulta/Alterar/1
        //[HttpPost]
        //[Route("Alterar/{id}")]
        //public IActionResult Alterar(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Consulta consulta = _consultaDAO.BuscarPorId(id);

        //        if (consulta != null)
        //        {
        //            if (_consultaDAO.Alterar(consulta))
        //            {
        //                return Created("", consulta);
        //            }
        //            return Conflict(new { msg = "Essa consulta já existe!" });
        //        }
        //        return BadRequest(ModelState);
        //        //return Ok(consulta);
        //    }
        //    return NotFound(new { msg = "Consulta não encontrada!" });
        //    }
    }

}
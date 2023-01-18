using ESH_ApiWithDapper.ApplicationService;
using ESH_ApiWithDapper.ApplicationService.RegisterMap;
using ESH_ApiWithDapper.ApplicationService.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly IFacade _facade;
        public TurmasController(IFacade facade)
        {
            _facade = facade;
        }

        [HttpGet, Route("obterTodos")]
        [ProducesResponseType(typeof(List<TurmaView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<TurmaView>> ObterTodos()
        {
            try
            {
                return Ok(_facade.Turmas.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpGet, Route("obterPor/{id}")]
        [ProducesResponseType(typeof(TurmaView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObterPor(int id)
        {
            try
            {
                return Ok(_facade.Turmas.ObterPor(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost, Route("salvar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Salvar(TurmaView view)
        {
            try
            {
                _facade.Turmas.Salvar(view);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete, Route("excluir/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Excluir(int id)
        {
            try
            {
                _facade.Turmas.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}

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
    public class AlunosController : ControllerBase
    {
        private readonly IFacade _facade;
        public AlunosController(IFacade facade)
        {
            _facade = facade;
        }

        [HttpGet, Route("obterTodos")]
        [ProducesResponseType(typeof(List<AlunoView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_facade.Alunos.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet, Route("obterPor/{id}")]
        [ProducesResponseType(typeof(AlunoView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObterPor(int id)
        {
            try
            {
                return Ok(_facade.Alunos.ObterPor(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet, Route("obterPaginado/{index}/{size}")]
        [ProducesResponseType(typeof(List<AlunoView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObterPaginado(int index, int size)
        {
            try
            {
                return Ok(_facade.Alunos.ObterPaginado(index, size));
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
        public IActionResult Salvar(AlunoView view)
        {
            try
            {
                _facade.Alunos.Salvar(view);
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
                _facade.Alunos.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}

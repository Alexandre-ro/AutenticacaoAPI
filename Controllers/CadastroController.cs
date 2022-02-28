using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.DTO;
using UsuarioAPI.Service;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _service;

        public CadastroController(CadastroService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Cadastra([FromBody] CreateUsuarioDTO dto)
        {
            Result resultado = _service.Cadastrar(dto);

            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}

using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.DTO;
using UsuarioAPI.Service;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CreateUsuarioDTO dto)
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

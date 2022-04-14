using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Data.Request;
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

            return Ok(resultado.Successes[0]);
        }

        [HttpGet("/ativar")]
        public IActionResult AtivarConta([FromQuery]AtivaContaRequest ativaContaRequest) 
        {
            Result resultado = _service.AtivarConta(ativaContaRequest);

            if (resultado.IsFailed) 
            {
                return StatusCode(500);
            }
            return Ok(resultado.Successes);
        }
    }
}

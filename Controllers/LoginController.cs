using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Data.Request;
using UsuarioAPI.Service;

namespace UsuarioAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _service;
        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest request)
        {
            Result result = _service.LogarUsuario(request);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors[0]);
            }

            return Ok(result.Successes[0]);
        }

        [HttpPost("/solicitar-troca-senha")]
        public IActionResult SolicitarResetSenha(SolicitaResetRequest request)
        {
            Result resultado = _service.SolicitarResetSenha(request);

            if (resultado.IsFailed)
            {
                return Unauthorized();
            }

            return Ok(resultado.Successes[0]);
        }

        [HttpPost("/efetuar-troca-senha")]
        public IActionResult EfeutarTrocaSenha(EfetuarResetSenhaRequest request)
        {
            Result resultado = _service.EfetuarTrocaSenha(request);

            if (resultado.IsFailed)
            {
                return Unauthorized();
            }

            return Ok(resultado.Successes[0]);
        }

    }
}

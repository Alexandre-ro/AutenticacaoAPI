using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Service;

namespace UsuarioAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogarUsuario() 
        {
            Result resultado = _logoutService.Deslogar();

            if (resultado.IsFailed) 
            {
                return Unauthorized(resultado.Errors[0]);
            }

            return Ok(resultado.Successes);
        }
    }
}

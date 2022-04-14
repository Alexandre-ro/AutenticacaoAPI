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
                return Unauthorized();            
            }

            return Ok();
        }
    }
}

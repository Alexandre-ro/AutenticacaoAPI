using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.DTO;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        public IActionResult Cadastra([FromBody] CreateUsuarioDTO dto ) 
        {
            return Ok();
        }
    }
}

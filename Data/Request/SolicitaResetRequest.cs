using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Data.Request
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}

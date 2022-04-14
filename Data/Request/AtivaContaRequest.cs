using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Data.Request
{
    public class AtivaContaRequest
    {
        [Required]
        public string CodigoAtivacao { get; set; }

        [Required]
        public int UsuarioId { get; set; }

    }
}

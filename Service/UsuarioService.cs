using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuarioAPI.Data.Request;
using UsuarioAPI.DTO;
using UsuarioAPI.Model;

namespace UsuarioAPI.Service
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;

        public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> manager, EmailService emailService)
        {
            _mapper      = mapper;
            _userManager = manager;
            _emailService = emailService;
        }

        public Result Cadastrar(CreateUsuarioDTO dto)
        {
            Usuario usuario                        = _mapper.Map<Usuario>(dto);
            IdentityUser<int> usuarioIdentity      = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, dto.Password);

            if (resultadoIdentity.Result.Succeeded)
            {
                var codigoAtivacao = _userManager
                                      .GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                var encodedCodigoAtivacao = HttpUtility.UrlEncode(codigoAtivacao);

                _emailService.EnviarEmail(new[] {usuarioIdentity.Email },
                                                 "Link de Ativação", 
                                                 usuarioIdentity.Id,
                                                 encodedCodigoAtivacao);

                return Result.Ok().WithSuccess(codigoAtivacao);
            }

            return Result.Fail("Ocorreu uma falha ao cadastrar o usuário");
        }

        public Result AtivarConta(AtivaContaRequest ativaContaRequest) 
        {
            var identiyUsuer = _userManager.Users
                                           .FirstOrDefault(u => u.Id == ativaContaRequest.UsuarioId);

            var identityResult = _userManager
                                  .ConfirmEmailAsync(identiyUsuer, ativaContaRequest.CodigoAtivacao).Result;

            if (identityResult.Succeeded) 
            {
                return Result.Ok();     
            }

            return Result.Fail("Ocorreu uma falha ao Realizar a Ativação do Usuário!");
        }
    }
}

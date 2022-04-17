using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using UsuarioAPI.Data.Request;
using UsuarioAPI.Model;

namespace UsuarioAPI.Service
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _sign;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> sign, TokenService tokenService)
        {
            _sign = sign;
            _tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultLogin = _sign.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultLogin.Result.Succeeded)
            {
                var identityUser = _sign.UserManager
                                        .Users.FirstOrDefault(
                                         usuario => usuario.NormalizedUserName == request.UserName.ToUpper());

                Token token = _tokenService.CriarToken(identityUser);

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Ocorreu uma falha ao realizar o Login!");
        }

        public Result SolicitarResetSenha(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = _sign
                                            .UserManager
                                            .Users
                                            .FirstOrDefault(u => u.NormalizedEmail == request.Email.ToUpper());

            if (identityUser != null)
            {
                string codigoAtivacao = _sign.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                return Result.Ok().WithSuccess(codigoAtivacao);
            }

            return Result.Fail("Ocorreu uma falha ao gerar o Código de Atiavação!");
        }

        public Result EfetuarTrocaSenha(EfetuarResetSenhaRequest request) 
        {
            IdentityUser<int> identityUser = _sign
                                            .UserManager
                                            .Users
                                            .FirstOrDefault(u => u.NormalizedEmail == request.Email.ToUpper());

            IdentityResult resultadoIdentity = _sign
                                               .UserManager
                                               .ResetPasswordAsync(identityUser, request.Token, request.Password)
                                               .Result;

            if (resultadoIdentity.Succeeded) 
            {
                return Result.Ok().WithSuccess("A Senha foi redefinada com sucesso!");
            }

            return Result.Fail("Ocorreu uma falha ao realizar a troca da Senha");
        }
    }
}

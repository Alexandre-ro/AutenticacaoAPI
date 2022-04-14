using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.Data.Request;

namespace UsuarioAPI.Service
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _sign;

        public LoginService(SignInManager<IdentityUser<int>> sign)
        {
            _sign = sign;
        }
        
        public Result LogarUsuario(LoginRequest request)
        {
            var resultLogin = _sign.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultLogin.Result.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Ocorreu uma falha ao realizar o Login!");
        }
    }
}

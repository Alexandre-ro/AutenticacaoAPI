using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuarioAPI.Service
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signManager = signInManager;
        }

        public Result Deslogar()
        {
            var resultadoIdentity = _signManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }

            return Result.Fail("Ocorreu uma falha ao realizar o Logout!");
        }
    }
}

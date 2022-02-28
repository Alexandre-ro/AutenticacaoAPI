using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsuarioAPI.DTO;
using UsuarioAPI.Model;

namespace UsuarioAPI.Service
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> manager)
        {
            _mapper = mapper;
            _userManager = manager;
        }

        public Result Cadastrar(CreateUsuarioDTO dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
           
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, dto.Password);

            if (resultadoIdentity.Result.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Ocorreu uma falha ao cadastrar o usuário");
        }
    }
}

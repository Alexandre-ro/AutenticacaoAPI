using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.DTO;
using UsuarioAPI.Model;

namespace UsuarioAPI.Profiles
{

    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}

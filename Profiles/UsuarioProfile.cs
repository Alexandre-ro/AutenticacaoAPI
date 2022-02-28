using AutoMapper;
using UsuarioAPI.DTO;
using UsuarioAPI.Model;

namespace UsuarioAPI.Profiles
{

    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
        }

    }
}

using AutoMapper;
using TAKEALURA.Data.Dtos.Filme;
using TAKEALURA.Models;

namespace TAKEALURA.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
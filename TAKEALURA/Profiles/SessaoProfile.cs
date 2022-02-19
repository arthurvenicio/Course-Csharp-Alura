using AutoMapper;
using System.Linq;
using TAKEALURA.Data.Dtos.Sessao;
using TAKEALURA.Models;

namespace TAKEALURA.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto => 
                dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duration * (-1))));
        }
    }
}

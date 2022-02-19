using AutoMapper;
using System.Linq;
using TAKEALURA.Data.Dtos.Gerente;
using TAKEALURA.Models;

namespace TAKEALURA.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(g => g.Cinemas
                .Select(c => new { c.Id, c.Name, c.Endereco ,c.EnderecoId})
                ));
            CreateMap<UpdateGerenteDto, Gerente>();
        }
    }
}
using AutoMapper;
using TAKEALURA.Data.Dtos.Endereco;
using TAKEALURA.Models;

namespace TAKEALURA.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
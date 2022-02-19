using AutoMapper;
using TAKEALURA.Data.Dtos.Cinema;
using TAKEALURA.Models;
using System.Linq;

namespace TAKEALURA.Profiles
{
    public class CinemaProfile  : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
        }
    }
}
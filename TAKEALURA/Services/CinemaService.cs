using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Cinema;
using TAKEALURA.Models;

namespace TAKEALURA.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadCinemaDto> GetAll() 
        {
            var filmes = _context.Cinemas.ToList();
           
            return _mapper.Map<List<ReadCinemaDto>>(filmes); ;
        }

        public ReadCinemaDto GetCinemaById(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cine = _mapper.Map<ReadCinemaDto>(cinema);
                return cine;
            }
            return null;
        }

        public ReadCinemaDto AddCinema(CreateCinemaDto cinemaDto)
        {
            Cinema newCinema = _mapper.Map<Cinema>(cinemaDto);

            var cinemaAlreadyExist = _context.Cinemas.FirstOrDefault(c => c.EnderecoId == newCinema.EnderecoId);
            if (cinemaAlreadyExist != null) return null;

            _context.Cinemas.Add(newCinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(newCinema);
        }

        public Result UpdateCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cine = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cine == null)
            {
                return Result.Fail("O cinema com esse id, não foi encontrado!");
            }
            _mapper.Map(cinemaDto, cine);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema == null)
            {
                return Result.Fail("O cinema com esse id, não foi encontrado!");
            }
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}

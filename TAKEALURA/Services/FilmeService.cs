using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Filme;
using TAKEALURA.Models;

namespace TAKEALURA.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AddFilm(CreateFilmeDto filme)
        {
            Filme film = _mapper.Map<Filme>(filme);
            _context.Filmes.Add(film);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(film);
        }

        public List<ReadFilmeDto> GetFilms(int? id)
        {
            List<Filme> filmes;

            if (id == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(f => f.Id == id).ToList();
            }

            return _mapper.Map<List<ReadFilmeDto>>(filmes);

        }

        public ReadFilmeDto GetFilm(int id)
        {
            Filme film = _context.Filmes.FirstOrDefault(p => p.Id == id);
            if (film != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(film);
                return filmeDto;
            }
            return null;
        }

        public Result UpdateFilm(int id, UpdateFilmeDto filmeDto)
        {
            Filme film = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (film == null)
            {
                return Result.Fail("Não foi encontrado um filme com esse Id!");
            }
            _mapper.Map(filmeDto, film);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteFilm(int id)
        {
            Filme film = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (film == null)
            {
                return Result.Fail("Não foi encontrado um filme com esse Id!");
            }
            _context.Remove(film);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}

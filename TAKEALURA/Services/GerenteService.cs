using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Gerente;
using TAKEALURA.Models;

namespace TAKEALURA.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadGerenteDto> GetAll(int? id)
        {
            List<Gerente> gerentes;

            if (id == null)
            {
                gerentes = _context.Gerentes.ToList();
            }
            else 
            {
                gerentes = _context.Gerentes.Where(g => g.Id == id).ToList();
            }
            return null;

        }

        public ReadGerenteDto AddGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public Result UpdateGerente(int id, UpdateGerenteDto gerenteDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);

            if (gerente == null)
            {
                return Result.Fail("O Gerente com o Id não foi encontrado!");
            }
            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);

            if (gerente == null)
            {
                return Result.Fail("O Gerente com o Id não foi encontrado!");
            }

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}

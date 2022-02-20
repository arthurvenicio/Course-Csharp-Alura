using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Endereco;
using TAKEALURA.Models;

namespace TAKEALURA.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadEnderecoDto> GetAll()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            if (enderecos == null) return null;
            return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
        }

        public ReadEnderecoDto GetEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(c => c.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto end = _mapper.Map<ReadEnderecoDto>(endereco);
                return end;
            }
            return null;
        }

        public ReadEnderecoDto AddEndereco(CreateEnderecoDto endereco)
        {
            Endereco newEndereco = _mapper.Map<Endereco>(endereco);
            _context.Enderecos.Add(newEndereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(newEndereco);
        }

        public Result UpdateEndereco(int id, UpdateEnderecoDto endereco)
        {
            Endereco ende = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if (ende == null)
            {
                return Result.Fail("Não foi encontrado um endereço com esse Id!");
            }
            _mapper.Map(endereco, ende);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(c => c.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Não foi encontrado um endereço com esse Id!");
            }
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}

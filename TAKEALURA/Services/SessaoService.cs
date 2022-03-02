using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Sessao;
using TAKEALURA.Models;

namespace TAKEALURA.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto GetSessaoById(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(s => s.Id == id);

            if (sessao != null)
            {
                ReadSessaoDto readSessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return readSessaoDto;
            }
            return null;
        }

        public ReadSessaoDto AddSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public List<ReadSessaoDto> GetAllSessoes(int? id)
        {

            List<Sessao> sessoes;
            
            if(id == null)
            {
                sessoes = _context.Sessoes.ToList();
            }
            else
            {
                sessoes = _context.Sessoes.Where(s => s.Id == id).ToList();

            }

            if(sessoes != null)
            {
                List<ReadSessaoDto> sessoesDto = _mapper.Map<List<ReadSessaoDto>>(sessoes);
                return sessoesDto;
            }

            return null;

        }
    }
}

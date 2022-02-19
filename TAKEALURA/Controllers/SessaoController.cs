using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Sessao;
using TAKEALURA.Models;


namespace TAKEALURA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly ILogger _logger;
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(ILogger<SessaoController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetSessaoById(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(s => s.Id == id);

            if(sessao != null)
            {
                ReadSessaoDto readSessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(readSessaoDto);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessaoById), new {Id = sessao.Id}, sessao);
        }
    }
}

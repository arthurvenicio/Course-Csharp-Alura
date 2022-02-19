using System.Linq;
using AutoMapper;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Gerente;
using TAKEALURA.Models;

namespace TAKEALURA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly ILogger<GerenteController> _logger;
        private AppDbContext _context;
        private IMapper _mapper;
        
        public GerenteController(ILogger<GerenteController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult getAll([FromQuery] int? id = null)
        {
            if (id != null)
            {
                Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
                if (gerente != null)
                {
                    ReadGerenteDto geren = _mapper.Map<ReadGerenteDto>(gerente);
                    return Ok(geren);
                }
                return NotFound();
            }
            
            return Ok(_context.Gerentes);
        }

        [HttpPost]
        public IActionResult AddGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getAll), gerente);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);

            if (gerente == null)
            {
                return NotFound();
            }

            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteGerente([FromQuery] int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);

            if (gerente == null)
            {
                return NotFound();
            }

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
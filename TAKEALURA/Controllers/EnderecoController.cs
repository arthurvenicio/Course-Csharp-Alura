using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Endereco;
using TAKEALURA.Models;
using System.Linq;

namespace TAKEALURA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly ILogger _logger;
        private AppDbContext _context;
        private IMapper _mapper;
     
        public EnderecoController(ILogger<EnderecoController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Enderecos);
        }
        
        [HttpGet("search")]
        public IActionResult GetEndereco([FromQuery]int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(c => c.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDto end = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(end);
            }
            return NotFound();
            
        }
        
        [HttpPost]
        public IActionResult AddEndereco([FromBody] CreateEnderecoDto endereco)
        {
            Endereco newEndereco = _mapper.Map<Endereco>(endereco);
            _context.Enderecos.Add(newEndereco);
            _context.SaveChanges();
            _logger.LogInformation("Create endereco and add in database with sucess!");
            return CreatedAtAction(nameof(GetEndereco), new { Id = newEndereco.Id}, endereco);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDto endereco)
        {
            Endereco ende = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if (ende == null)
            {
                return NotFound();
            }

            _mapper.Map(endereco, ende);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(c => c.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Cinema;
using TAKEALURA.Models;

namespace TAKEALURA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ILogger _logger;
        private AppDbContext _context;
        private IMapper _mapper;
        
        public CinemaController(ILogger<CinemaController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Cinemas);
        }
        
        [HttpGet("search")]
        public IActionResult GetCinema([FromQuery]int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if (cinema != null)
            {
                ReadCinemaDto cine = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cine);
            }
            return NotFound();
            
        }
        
        [HttpPost]
        public IActionResult AddCinema([FromBody] CreateCinemaDto cinema)
        {
            Cinema newCinema = _mapper.Map<Cinema>(cinema);
            _context.Cinemas.Add(newCinema);
            _context.SaveChanges();
            _logger.LogInformation("Create cinema and add in database with sucess!");
            return CreatedAtAction(nameof(GetCinema), new { Id = newCinema.Id}, cinema);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinema)
        {
            Cinema cine = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if (cine == null)
            {
                return NotFound();
            }

            _mapper.Map(cinema, cine);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
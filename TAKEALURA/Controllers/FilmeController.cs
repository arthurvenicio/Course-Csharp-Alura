using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Filme;
using TAKEALURA.Models;

namespace TAKEALURA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private readonly ILogger<FilmeController> _logger;

        public FilmeController(AppDbContext context, ILogger<FilmeController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        
        
        [HttpPost]
        public IActionResult AddFilm([FromBody] CreateFilmeDto filme)
        {
            Filme film = _mapper.Map<Filme>(filme);
            _context.Filmes.Add(film);
            _context.SaveChanges();
            _logger.LogInformation("Created an Film and add in Database with sucess!");
            return CreatedAtAction(nameof(GetFilm), new {Id = film.Id}, film);
        }
        
        [HttpGet]
        public IActionResult GetFilms(int? id = null)
        {
            if (id != null)
            {
                Filme film = _context.Filmes.FirstOrDefault(p => p.Id == id);
                if (film != null)
                {
                    ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(film);
                    return Ok(filmeDto);
                }
                return NotFound();  
            }
            
            var filmes = _context.Filmes;
            return Ok(filmes);
        }
        
        [HttpGet("search")]
        public IActionResult GetFilm([FromQuery] int id)
        {
            Filme film = _context.Filmes.FirstOrDefault(p => p.Id == id);
            if (film != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(film);
                return Ok(filmeDto);
            }
            return NotFound();  
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmeDto filmeNovo)
        {
            Filme film = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            _mapper.Map(filmeNovo, film);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            Filme film = _context.Filmes.FirstOrDefault(f => f.Id == id); 
            if (film == null)
            {
                return NotFound();
            }

            _context.Remove(film);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
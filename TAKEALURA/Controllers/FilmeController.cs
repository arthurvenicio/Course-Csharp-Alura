using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Filme;
using TAKEALURA.Models;
using TAKEALURA.Services;

namespace TAKEALURA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {

        private FilmeService _filmeService;
        private readonly ILogger<FilmeController> _logger;

        public FilmeController(ILogger<FilmeController> logger, FilmeService filmeService)
        {
            _filmeService = filmeService;
            _logger = logger;
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddFilm([FromBody] CreateFilmeDto filme)
        {
            ReadFilmeDto filmDto = _filmeService.AddFilm(filme);
            _logger.LogInformation("Created an Film and add in Database with sucess!");
            return CreatedAtAction(nameof(GetFilm), new {Id = filmDto.Id}, filmDto);
        }
        [Authorize(Roles = "admin, regular")]
        [HttpGet]
        public IActionResult GetFilms(int? id = null)
        {
            List<ReadFilmeDto> filmes = _filmeService.GetFilms(id);
            if(filmes == null) return NotFound();
            return Ok(filmes);
        }
        [Authorize(Roles = "admin, regular")]
        [HttpGet("search")]
        public IActionResult GetFilm([FromQuery] int id)
        {
            ReadFilmeDto filme = _filmeService.GetFilm(id);
            if(filme == null) return NotFound();
            return Ok(filme);
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmeDto filmeNovo)
        {
            Result resultado = _filmeService.UpdateFilm(id, filmeNovo);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            Result resultado = _filmeService.DeleteFilm(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
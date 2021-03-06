using System;
using System.Collections.Generic;
using System.Linq;
using ApiCinema.Models.Erros;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Cinema;
using TAKEALURA.Models;
using TAKEALURA.Services;

namespace TAKEALURA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ILogger _logger;
        private CinemaService _cinemaService;
        
        public CinemaController(ILogger<CinemaController> logger, CinemaService cinemaService)
        {
            _logger = logger;
            _cinemaService = cinemaService;
        }

        [Authorize(Roles = "admin, regular")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ReadCinemaDto> readDto = _cinemaService.GetAll();
            if(readDto == null) return NotFound();
            return Ok(readDto);
        }

        [Authorize(Roles = "admin, regular")]
        [HttpGet("search")]
        public IActionResult GetCinema([FromQuery]int id)
        {
            ReadCinemaDto cinemaDto = _cinemaService.GetCinemaById(id);
            if(cinemaDto != null) return Ok(cinemaDto);
            return NotFound();    
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddCinema([FromBody] CreateCinemaDto cinema)
        {
            ReadCinemaDto readDto = _cinemaService.AddCinema(cinema);
            if (readDto == null) return BadRequest(new CreateCinemaError() { Sucess = false, ErrorMessage = "Has an cinema with this location id!", consultAt = DateTime.Now });
            _logger.LogInformation("Create cinema and add in database with sucess!");
            return CreatedAtAction(nameof(GetCinema), new { Id = readDto.Id }, readDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinema)
        {
            Result resultado = _cinemaService.UpdateCinema(id, cinema);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            Result resultado = _cinemaService.DeleteCinema(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
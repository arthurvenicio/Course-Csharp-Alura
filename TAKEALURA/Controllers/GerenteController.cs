using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Core.Logging;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Gerente;
using TAKEALURA.Models;
using TAKEALURA.Services;

namespace TAKEALURA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly ILogger<GerenteController> _logger;
        private GerenteService _gerenteService;
        
        public GerenteController(ILogger<GerenteController> logger, GerenteService gerenteService)
        {
            _logger = logger;
            _gerenteService = gerenteService;
        }
        [Authorize(Roles = "admin, regular")]
        [HttpGet]
        public IActionResult getAll([FromQuery] int? id = null)
        {
            List<ReadGerenteDto> gerentes = _gerenteService.GetAll(id);
            if(gerentes == null) return NotFound();
            return Ok(gerentes);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readDto = _gerenteService.AddGerente(gerenteDto);
            return CreatedAtAction(nameof(getAll), new { Id = readDto.Id}, readDto);
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Result resultado = _gerenteService.UpdateGerente(id, gerenteDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public IActionResult DeleteGerente([FromQuery] int id)
        {
            Result resultado = _gerenteService.DeleteGerente(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
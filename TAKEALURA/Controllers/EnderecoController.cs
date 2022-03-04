using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Endereco;
using TAKEALURA.Models;
using System.Linq;
using TAKEALURA.Services;
using System.Collections.Generic;
using FluentResults;
using Microsoft.AspNetCore.Authorization;

namespace TAKEALURA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly ILogger _logger;
        private EnderecoService _enderecoService;

        public EnderecoController(ILogger<EnderecoController> logger, EnderecoService enderecoService)
        {
            _logger = logger;
            _enderecoService = enderecoService;
        }
        [Authorize(Roles = "admin, regular")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ReadEnderecoDto> enderecos = _enderecoService.GetAll();
            if(enderecos == null) return NotFound();
            return Ok(enderecos);
        }
        [Authorize(Roles = "admin, regular")]
        [HttpGet("search")]
        public IActionResult GetEndereco([FromQuery]int id)
        {
            ReadEnderecoDto endereco = _enderecoService.GetEndereco(id);
            if (endereco == null) return NotFound();
            return Ok(endereco);        
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddEndereco([FromBody] CreateEnderecoDto endereco)
        {
            ReadEnderecoDto newEndereco = _enderecoService.AddEndereco(endereco);
            return CreatedAtAction(nameof(GetEndereco), new { Id = newEndereco.Id}, newEndereco);
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDto endereco)
        {
            Result resultado = _enderecoService.UpdateEndereco(id, endereco);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            Result resultado = _enderecoService.DeleteEndereco(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        
    }
}
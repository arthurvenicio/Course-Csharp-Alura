using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TAKEALURA.Data;
using TAKEALURA.Data.Dtos.Sessao;
using TAKEALURA.Models;
using TAKEALURA.Services;

namespace TAKEALURA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly ILogger _logger;
        private SessaoService _sessaoService;

        public SessaoController(ILogger<SessaoController> logger, SessaoService sessaoService)
        {
            _logger = logger;
            _sessaoService = sessaoService;
        }

        [HttpGet("{id}")]
        public IActionResult GetSessaoById(int id)
        {
            ReadSessaoDto readDto = _sessaoService.GetSessaoById(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet]
        public IActionResult GetAllSessoes(int? id = null)
        {
            List<ReadSessaoDto> sessions = _sessaoService.GetAllSessoes(id);
            if(sessions == null) return NotFound(); 
            return Ok(sessions);
        }

        [HttpPost]
        public IActionResult AddSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = _sessaoService.AddSessao(sessaoDto);

            return CreatedAtAction(nameof(GetSessaoById), new {Id = readDto.Id}, readDto);
        }
    }
}

using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HqPersonagemController : ControllerBase
    {
        private readonly IHqPersonagemRepository _hqPersonagemRepository;

        public HqPersonagemController(IHqPersonagemRepository hqPersonagemRepository)
        {
            _hqPersonagemRepository = hqPersonagemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HqPersonagem>>> GetAll()
        {
            var hqPersonagens = await _hqPersonagemRepository.GetAllAsync();
            return Ok(hqPersonagens);
        }

        [HttpGet("{hqId}/{personagemId}")]
        public async Task<ActionResult<HqPersonagem>> GetById(int hqId, int personagemId)
        {
            var hqPersonagem = await _hqPersonagemRepository.GetByIdAsync(hqId, personagemId);
            if (hqPersonagem == null)
            {
                return NotFound();
            }
            return Ok(hqPersonagem);
        }

        [HttpPost]
        public async Task<ActionResult> Add(HqPersonagem hqPersonagem)
        {
            await _hqPersonagemRepository.AddAsync(hqPersonagem);
            return CreatedAtAction(nameof(GetById), new { hqId = hqPersonagem.HqId, personagemId = hqPersonagem.PersonagemId }, hqPersonagem);
        }

        [HttpDelete("{hqId}/{personagemId}")]
        public async Task<ActionResult> Delete(int hqId, int personagemId)
        {
            await _hqPersonagemRepository.DeleteAsync(hqId, personagemId);
            return NoContent();
        }
    }
}
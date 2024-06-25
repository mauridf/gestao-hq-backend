using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemRepository _personagemRepository;

        public PersonagemController(IPersonagemRepository personagemRepository)
        {
            _personagemRepository = personagemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetAll()
        {
            var personagens = await _personagemRepository.GetAllAsync();
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> GetById(int id)
        {
            var personagem = await _personagemRepository.GetByIdAsync(id);
            if (personagem == null)
            {
                return NotFound();
            }
            return Ok(personagem);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Personagem personagem)
        {
            await _personagemRepository.AddAsync(personagem);
            return CreatedAtAction(nameof(GetById), new { id = personagem.Id }, personagem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Personagem personagem)
        {
            if (id != personagem.Id)
            {
                return BadRequest();
            }
            await _personagemRepository.UpdateAsync(personagem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personagemRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
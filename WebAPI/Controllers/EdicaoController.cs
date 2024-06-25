using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdicaoController : ControllerBase
    {
        private readonly IEdicaoRepository _edicaoRepository;

        public EdicaoController(IEdicaoRepository edicaoRepository)
        {
            _edicaoRepository = edicaoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Edicao>>> GetAll()
        {
            var edicoes = await _edicaoRepository.GetAllAsync();
            return Ok(edicoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Edicao>> GetById(int id)
        {
            var edicao = await _edicaoRepository.GetByIdAsync(id);
            if (edicao == null)
            {
                return NotFound();
            }
            return Ok(edicao);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Edicao edicao)
        {
            await _edicaoRepository.AddAsync(edicao);
            return CreatedAtAction(nameof(GetById), new { id = edicao.Id }, edicao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Edicao edicao)
        {
            if (id != edicao.Id)
            {
                return BadRequest();
            }
            await _edicaoRepository.UpdateAsync(edicao);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _edicaoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
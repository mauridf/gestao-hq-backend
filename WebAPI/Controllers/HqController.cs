using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HqController : ControllerBase
    {
        private readonly IHqRepository _hqRepository;

        public HqController(IHqRepository hqRepository)
        {
            _hqRepository = hqRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HQ>>> GetAll()
        {
            var hqs = await _hqRepository.GetAllAsync();
            return Ok(hqs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HQ>> GetById(int id)
        {
            var hq = await _hqRepository.GetByIdAsync(id);
            if (hq == null)
            {
                return NotFound();
            }
            return Ok(hq);
        }

        [HttpPost]
        public async Task<ActionResult> Add(HQ hq)
        {
            await _hqRepository.AddAsync(hq);
            return CreatedAtAction(nameof(GetById), new { id = hq.Id }, hq);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, HQ hq)
        {
            if (id != hq.Id)
            {
                return BadRequest();
            }
            await _hqRepository.UpdateAsync(hq);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _hqRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
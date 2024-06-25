using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HqEditoraController : ControllerBase
    {
        private readonly IHqEditoraRepository _hqEditoraRepository;

        public HqEditoraController(IHqEditoraRepository hqEditoraRepository)
        {
            _hqEditoraRepository = hqEditoraRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HqEditora>>> GetAll()
        {
            var hqEditoras = await _hqEditoraRepository.GetAllAsync();
            return Ok(hqEditoras);
        }

        [HttpGet("{hqId}/{editoraId}")]
        public async Task<ActionResult<HqEditora>> GetById(int hqId, int editoraId)
        {
            var hqEditora = await _hqEditoraRepository.GetByIdAsync(hqId, editoraId);
            if (hqEditora == null)
            {
                return NotFound();
            }
            return Ok(hqEditora);
        }

        [HttpPost]
        public async Task<ActionResult> Add(HqEditora hqEditora)
        {
            await _hqEditoraRepository.AddAsync(hqEditora);
            return CreatedAtAction(nameof(GetById), new { hqId = hqEditora.HqId, editoraId = hqEditora.EditoraId }, hqEditora);
        }

        [HttpDelete("{hqId}/{editoraId}")]
        public async Task<ActionResult> Delete(int hqId, int editoraId)
        {
            await _hqEditoraRepository.DeleteAsync(hqId, editoraId);
            return NoContent();
        }
    }
}
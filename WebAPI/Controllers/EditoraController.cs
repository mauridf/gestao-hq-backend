using gestao_hq_backend.Application.Services;
using gestao_hq_backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace gestao_hq_backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditoraController : ControllerBase
    {
        private readonly EditoraService _editoraService;

        public EditoraController(EditoraService editoraService)
        {
            _editoraService = editoraService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var editoras = await _editoraService.GetAllAsync();
                return Ok(editoras);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar editoras: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var editora = await _editoraService.GetByIdAsync(id);
                if (editora == null)
                    return NotFound();

                return Ok(editora);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar editora por ID: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Editora editora)
        {
            try
            {
                await _editoraService.AddAsync(editora);
                return CreatedAtAction(nameof(GetById), new { id = editora.Id }, editora);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar editora: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Editora editora)
        {
            try
            {
                if (id != editora.Id)
                    return BadRequest("ID da editora não corresponde");

                await _editoraService.UpdateAsync(editora);
                return Ok(editora);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar editora: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _editoraService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir editora: {ex.Message}");
            }
        }
    }
}
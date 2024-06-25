using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;

namespace gestao_hq_backend.Application.Services
{
    public class EditoraService
    {
        private readonly IEditoraRepository _editoraRepository;

        public EditoraService(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public async Task<IEnumerable<Editora>> GetAllAsync()
        {
            return await _editoraRepository.GetAllAsync();
        }

        public async Task<Editora> GetByIdAsync(int id)
        {
            return await _editoraRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Editora editora)
        {
            await _editoraRepository.AddAsync(editora);
        }

        public async Task UpdateAsync(Editora editora)
        {
            await _editoraRepository.UpdateAsync(editora);
        }

        public async Task DeleteAsync(int id)
        {
            await _editoraRepository.DeleteAsync(id);
        }
    }
}
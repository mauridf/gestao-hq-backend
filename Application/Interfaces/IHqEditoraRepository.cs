using gestao_hq_backend.Domain.Entities;

namespace gestao_hq_backend.Application.Interfaces
{
    public interface IHqEditoraRepository
    {
        Task<IEnumerable<HqEditora>> GetAllAsync();
        Task<HqEditora> GetByIdAsync(int hqId, int editoraId);
        Task AddAsync(HqEditora hqEditora);
        Task DeleteAsync(int hqId, int editoraId);
    }
}

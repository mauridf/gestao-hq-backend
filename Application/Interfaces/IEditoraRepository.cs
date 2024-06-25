using gestao_hq_backend.Domain.Entities;

namespace gestao_hq_backend.Application.Interfaces
{
    public interface IEditoraRepository
    {
        Task<IEnumerable<Editora>> GetAllAsync();
        Task<Editora> GetByIdAsync(int id);
        Task AddAsync(Editora editora);
        Task UpdateAsync(Editora editora);
        Task DeleteAsync(int id);
    }
}

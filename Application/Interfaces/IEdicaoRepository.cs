using gestao_hq_backend.Domain.Entities;

namespace gestao_hq_backend.Application.Interfaces
{
    public interface IEdicaoRepository
    {
        Task<IEnumerable<Edicao>> GetAllAsync();
        Task<Edicao> GetByIdAsync(int id);
        Task AddAsync(Edicao edicao);
        Task UpdateAsync(Edicao edicao);
        Task DeleteAsync(int id);
    }
}

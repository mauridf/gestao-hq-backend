using gestao_hq_backend.Domain.Entities;

namespace gestao_hq_backend.Application.Interfaces
{
    public interface IHqRepository
    {
        Task<IEnumerable<HQ>> GetAllAsync();
        Task<HQ> GetByIdAsync(int id);
        Task AddAsync(HQ hq);
        Task UpdateAsync(HQ hq);
        Task DeleteAsync(int id);
    }
}

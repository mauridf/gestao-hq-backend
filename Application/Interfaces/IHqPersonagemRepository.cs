using gestao_hq_backend.Domain.Entities;

namespace gestao_hq_backend.Application.Interfaces
{
    public interface IHqPersonagemRepository
    {
        Task<IEnumerable<HqPersonagem>> GetAllAsync();
        Task<HqPersonagem> GetByIdAsync(int hqId, int personagemId);
        Task AddAsync(HqPersonagem hqPersonagem);
        Task DeleteAsync(int hqId, int personagemId);
    }
}

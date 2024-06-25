using gestao_hq_backend.Domain.Entities;

namespace gestao_hq_backend.Application.Interfaces
{
    public interface IPersonagemRepository
    {
        Task<IEnumerable<Personagem>> GetAllAsync();
        Task<Personagem> GetByIdAsync(int id);
        Task AddAsync(Personagem personagem);
        Task UpdateAsync(Personagem personagem);
        Task DeleteAsync(int id);
    }
}

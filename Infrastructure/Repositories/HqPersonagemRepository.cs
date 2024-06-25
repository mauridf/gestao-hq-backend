using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Infrastructure.Data.Repositories
{
    public class HqPersonagemRepository : IHqPersonagemRepository
    {
        private readonly ApplicationDbContext _context;

        public HqPersonagemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HqPersonagem>> GetAllAsync()
        {
            return await _context.HqPersonagens.ToListAsync();
        }

        public async Task<HqPersonagem> GetByIdAsync(int hqId, int personagemId)
        {
            return await _context.HqPersonagens.FindAsync(hqId, personagemId);
        }

        public async Task AddAsync(HqPersonagem hqPersonagem)
        {
            await _context.HqPersonagens.AddAsync(hqPersonagem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HqPersonagem hqPersonagem)
        {
            _context.HqPersonagens.Update(hqPersonagem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int hqId, int personagemId)
        {
            var hqPersonagem = await _context.HqPersonagens.FindAsync(hqId, personagemId);
            if (hqPersonagem != null)
            {
                _context.HqPersonagens.Remove(hqPersonagem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
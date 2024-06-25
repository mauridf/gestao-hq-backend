using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Infrastructure.Data.Repositories
{
    public class HqRepository : IHqRepository
    {
        private readonly ApplicationDbContext _context;

        public HqRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HQ>> GetAllAsync()
        {
            return await _context.HQs.ToListAsync();
        }

        public async Task<HQ> GetByIdAsync(int id)
        {
            return await _context.HQs.FindAsync(id);
        }

        public async Task AddAsync(HQ hq)
        {
            await _context.HQs.AddAsync(hq);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HQ hq)
        {
            _context.HQs.Update(hq);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hq = await _context.HQs.FindAsync(id);
            if (hq != null)
            {
                _context.HQs.Remove(hq);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Infrastructure.Data.Repositories
{
    public class HqEditoraRepository : IHqEditoraRepository
    {
        private readonly ApplicationDbContext _context;

        public HqEditoraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HqEditora>> GetAllAsync()
        {
            return await _context.HqEditoras.ToListAsync();
        }

        public async Task<HqEditora> GetByIdAsync(int hqId, int editoraId)
        {
            return await _context.HqEditoras.FindAsync(hqId, editoraId);
        }

        public async Task AddAsync(HqEditora hqEditora)
        {
            await _context.HqEditoras.AddAsync(hqEditora);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HqEditora hqEditora)
        {
            _context.HqEditoras.Update(hqEditora);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int hqId, int editoraId)
        {
            var hqEditora = await _context.HqEditoras.FindAsync(hqId, editoraId);
            if (hqEditora != null)
            {
                _context.HqEditoras.Remove(hqEditora);
                await _context.SaveChangesAsync();
            }
        }
    }
}
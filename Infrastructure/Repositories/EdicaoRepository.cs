using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Infrastructure.Data.Repositories
{
    public class EdicaoRepository : IEdicaoRepository
    {
        private readonly ApplicationDbContext _context;

        public EdicaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Edicao>> GetAllAsync()
        {
            return await _context.Edicoes.ToListAsync();
        }

        public async Task<Edicao> GetByIdAsync(int id)
        {
            return await _context.Edicoes.FindAsync(id);
        }

        public async Task AddAsync(Edicao edicao)
        {
            await _context.Edicoes.AddAsync(edicao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Edicao edicao)
        {
            _context.Edicoes.Update(edicao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var edicao = await _context.Edicoes.FindAsync(id);
            if (edicao != null)
            {
                _context.Edicoes.Remove(edicao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
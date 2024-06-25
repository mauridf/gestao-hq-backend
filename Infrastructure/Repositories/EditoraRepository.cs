using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using gestao_hq_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gestao_hq_backend.Infrastructure.Repositories
{
    public class EditoraRepository : IEditoraRepository
    {
        private readonly ApplicationDbContext _context;

        public EditoraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Editora>> GetAllAsync()
        {
            return await _context.Editoras.ToListAsync();
        }

        public async Task<Editora> GetByIdAsync(int id)
        {
            return await _context.Editoras.FindAsync(id);
        }

        public async Task AddAsync(Editora editora)
        {
            await _context.Editoras.AddAsync(editora);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Editora editora)
        {
            _context.Entry(editora).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);
            _context.Editoras.Remove(editora);
            await _context.SaveChangesAsync();
        }
    }

}

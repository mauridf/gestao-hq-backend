using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestao_hq_backend.Infrastructure.Data.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonagemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personagem>> GetAllAsync()
        {
            return await _context.Personagens.ToListAsync();
        }

        public async Task<Personagem> GetByIdAsync(int id)
        {
            return await _context.Personagens.FindAsync(id);
        }

        public async Task AddAsync(Personagem personagem)
        {
            await _context.Personagens.AddAsync(personagem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Personagem personagem)
        {
            _context.Personagens.Update(personagem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var personagem = await _context.Personagens.FindAsync(id);
            if (personagem != null)
            {
                _context.Personagens.Remove(personagem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
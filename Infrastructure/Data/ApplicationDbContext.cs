using gestao_hq_backend.Domain.Entities;
using gestao_hq_backend.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace gestao_hq_backend.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<HQ> HQs { get; set; }
        public DbSet<Edicao> Edicoes { get; set; }
        public DbSet<HqEditora> HqEditoras { get; set; }
        public DbSet<HqPersonagem> HqPersonagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EditoraConfiguration());
            modelBuilder.ApplyConfiguration(new PersonagemConfiguration());
            modelBuilder.ApplyConfiguration(new EdicaoConfiguration());
            modelBuilder.ApplyConfiguration(new HqConfiguration());
            modelBuilder.ApplyConfiguration(new HqEditoraConfiguration());
            modelBuilder.ApplyConfiguration(new HqPersonagemConfiguration());
        }
    }
}
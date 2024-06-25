using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestao_hq_backend.Infrastructure.Data.Configurations
{
    public class PersonagemConfiguration : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.TipoPersonagem)
                   .IsRequired();

            builder.Property(p => p.Descricao)
                   .HasMaxLength(500);
        }
    }
}

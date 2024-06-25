using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestao_hq_backend.Infrastructure.Data.Configurations
{
    public class HqPersonagemConfiguration : IEntityTypeConfiguration<HqPersonagem>
    {
        public void Configure(EntityTypeBuilder<HqPersonagem> builder)
        {
            builder.HasKey(hp => new { hp.HqId, hp.PersonagemId });

            builder.HasOne(hp => hp.Hq)
                   .WithMany(h => h.HqPersonagens)
                   .HasForeignKey(hp => hp.HqId);

            builder.HasOne(hp => hp.Personagem)
                   .WithMany(p => p.HqPersonagens)
                   .HasForeignKey(hp => hp.PersonagemId);
        }
    }
}
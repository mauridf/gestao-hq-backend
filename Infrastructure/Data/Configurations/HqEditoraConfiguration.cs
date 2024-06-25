using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestao_hq_backend.Infrastructure.Data.Configurations
{
    public class HqEditoraConfiguration : IEntityTypeConfiguration<HqEditora>
    {
        public void Configure(EntityTypeBuilder<HqEditora> builder)
        {
            builder.HasKey(he => new { he.HqId, he.EditoraId });

            builder.HasOne(he => he.Hq)
                   .WithMany(h => h.HqEditoras)
                   .HasForeignKey(he => he.HqId);

            builder.HasOne(he => he.Editora)
                   .WithMany(e => e.HqEditoras)
                   .HasForeignKey(he => he.EditoraId);
        }
    }
}
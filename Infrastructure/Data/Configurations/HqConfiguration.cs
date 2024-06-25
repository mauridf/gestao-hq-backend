using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestao_hq_backend.Infrastructure.Data.Configurations
{
    public class HqConfiguration : IEntityTypeConfiguration<HQ>
    {
        public void Configure(EntityTypeBuilder<HQ> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.NomeHq)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(h => h.NomeOriginalHq)
                   .HasMaxLength(200);

            builder.Property(h => h.Publicacao)
                   .IsRequired();

            builder.Property(h => h.Status)
                   .IsRequired();

            builder.Property(h => h.TotalEdicoes)
                   .HasMaxLength(100);

            builder.Property(h => h.Sinopse)
                   .HasMaxLength(1000);
        }
    }
}
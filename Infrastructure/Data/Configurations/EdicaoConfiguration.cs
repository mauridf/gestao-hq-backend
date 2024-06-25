using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestao_hq_backend.Infrastructure.Data.Configurations
{
    public class EdicaoConfiguration : IEntityTypeConfiguration<Edicao>
    {
        public void Configure(EntityTypeBuilder<Edicao> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Titulo)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Obs)
                   .HasMaxLength(500);

            builder.HasOne(e => e.Hq)
                   .WithMany(h => h.Edicoes)
                   .HasForeignKey(e => e.HqId);
        }
    }
}
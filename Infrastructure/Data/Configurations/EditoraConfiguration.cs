using gestao_hq_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestao_hq_backend.Infrastructure.Data.Configurations
{
    public class EditoraConfiguration : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.NomeEditora).IsRequired().HasMaxLength(255);
        }
    }
}
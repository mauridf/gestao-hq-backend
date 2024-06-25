using gestao_hq_backend.Domain.Enums;

namespace gestao_hq_backend.Domain.Entities
{
    public class HQ
    {
        public int Id { get; set; }
        public string NomeHq { get; set; }
        public string NomeOriginalHq { get; set; }
        public Publicacao Publicacao { get; set; }
        public Status Status { get; set; }
        public string TotalEdicoes { get; set; }
        public string Sinopse { get; set; }
        public ICollection<Edicao>? Edicoes { get; set; }
        public ICollection<HqEditora>? HqEditoras { get; set; }
        public ICollection<HqPersonagem>? HqPersonagens { get; set; }
    }

}

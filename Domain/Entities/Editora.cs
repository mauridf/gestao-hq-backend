namespace gestao_hq_backend.Domain.Entities
{
    public class Editora
    {
        public int Id { get; set; }
        public string NomeEditora { get; set; }
        public ICollection<HqEditora>? HqEditoras { get; set; }
    }

}

namespace gestao_hq_backend.Domain.Entities
{
    public class HqEditora
    {
        public int HqId { get; set; }
        public HQ Hq { get; set; }
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }
    }
}

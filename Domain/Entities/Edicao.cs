namespace gestao_hq_backend.Domain.Entities
{
    public class Edicao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Obs { get; set; }
        public int HqId { get; set; }
        public HQ? Hq { get; set; }
    }

}

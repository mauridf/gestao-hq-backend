namespace gestao_hq_backend.Domain.Entities
{
    public class HqPersonagem
    {
        public int HqId { get; set; }
        public HQ Hq { get; set; }
        public int PersonagemId { get; set; }
        public Personagem Personagem { get; set; }
    }

}

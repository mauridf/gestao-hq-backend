using gestao_hq_backend.Domain.Enums;

namespace gestao_hq_backend.Domain.Entities
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoPersonagem TipoPersonagem { get; set; }
        public string Descricao { get; set; }
        public ICollection<HqPersonagem>? HqPersonagens { get; set; }
    }

}

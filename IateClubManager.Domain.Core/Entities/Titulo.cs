namespace IateClubManager.Domain.Core.Entities
{
    public class Titulo
    {
        private const byte MaxEmbarcacoes = 2;
        public int Id { get; set; }
        public Socio Socio { get; set; } = new();
        public List<Embarcacao> Embarcacoes { get; set; } = new();
    }
}

namespace IateClubManager.Domain.Core.Entities
{
    public class Socio
    {
        private const byte MaxDependentes = 4;
        private const byte MaxTripulantes = 2;
        public int ID { get; set; }
        public Pessoa? Pessoa { get; set; }
        public Pessoa? Responsavel { get; set; }
        public List<Pessoa> Dependentes { get; set; } = new();
        public List<Pessoa> Tripulantes { get; set; } = new();
    }
}

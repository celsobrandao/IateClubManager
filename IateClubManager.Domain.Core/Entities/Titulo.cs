namespace IateClubManager.Domain.Core.Entities
{
    public class Titulo
    {
        private const byte MaxEmbarcacoes = 2;
        public int Id { get; set; }
        public Socio? Socio { get; set; }
        public List<Embarcacao> Embarcacoes { get; set; } = new();

        public void AlterarSocio(Socio socio)
        {
            Socio = socio;
        }

        public bool AdicionarEmbarcacao(Embarcacao embarcacao)
        {
            if (PodeAdicionarEmbarcacao(embarcacao.ID))
            {
                Embarcacoes.Add(embarcacao);
                return true;
            }
            return false;
        }

        public bool RemoverEmbarcacao(Embarcacao embarcacao) 
            => Embarcacoes.Remove(embarcacao);

        private bool PodeAdicionarEmbarcacao(int id)
            => Embarcacoes.Count < MaxEmbarcacoes && Embarcacoes.Any(e => e.ID == id) == false;
    }
}

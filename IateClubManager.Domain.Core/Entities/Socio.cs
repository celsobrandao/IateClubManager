namespace IateClubManager.Domain.Core.Entities
{
    public class Socio
    {
        private const byte MaxDependentes = 4;
        private const byte MaxTripulantes = 2;
        public int Id { get; set; }
        public Pessoa? Pessoa { get; set; }
        public Pessoa? Responsavel { get; set; }
        public List<Pessoa> Dependentes { get; private set; } = new();
        public List<Pessoa> Tripulantes { get; private set; } = new();

        public bool AdicionarDependente(Pessoa dependente)
        {
            if (Dependentes.Count < MaxDependentes)
            {
                Dependentes.Add(dependente);
                return true;
            }
            return false;
        }

        public bool AdicionarTripulante(Pessoa tripulante)
        {
            if (Tripulantes.Count < MaxTripulantes)
            {
                Tripulantes.Add(tripulante);
                return true;
            }
            return false;
        }

        public bool EhValido()
        {
            if (Pessoa == null)
            {
                return false;
            }

            if (Pessoa?.TipoPessoa == Enums.TipoPessoaEnum.PJ && Responsavel == null)
            {
                return false;
            }

            return true;
        }
    }
}

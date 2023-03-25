namespace IateClubManager.Domain.Core.Entities
{
    public class Socio
    {
        private const byte MaxDependentes = 4;
        private const byte MaxTripulantes = 2;

        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }
        public Pessoa Responsavel { get; set; }
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

        public bool RemoverDependente(Pessoa dependente)
            => Dependentes.Remove(dependente);

        public bool AdicionarTripulante(Pessoa tripulante)
        {
            if (Tripulantes.Count < MaxTripulantes)
            {
                Tripulantes.Add(tripulante);
                return true;
            }
            return false;
        }

        public bool RemoverTripulante(Pessoa tripulante)
            => Tripulantes.Remove(tripulante);

        public bool EhValido()
        {
            if (Pessoa == null)
            {
                return false;
            }
            else if (!Pessoa.EhValido())
            {
                return false;
            }
            else if (Pessoa.TipoPessoa == Enums.TipoPessoaEnum.PJ && Responsavel == null)
            {
                return false;
            }

            if (Responsavel != null && !Responsavel.EhValido())
            {
                return false;
            }

            if (Dependentes.Any(d => !d.EhValido()))
            {
                return false;
            }

            if (Tripulantes.Any(t => !t.EhValido()))
            {
                return false;
            }

            return true;
        }
    }
}

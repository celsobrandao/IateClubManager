using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Domain.Navegacao.Entities
{
    public class PlanoNavegacao
    {
        public int Id { get; set; }
        public Titulo Titulo { get; set; }
        public Embarcacao Embarcacao { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetornoPrevista { get; set; }
        public DateTime DataRetornoEfetiva { get; set; }
        public string Destino { get; set; }
        public Pessoa Responsavel { get; set; }
        public List<Passageiro> Passageiros { get; set; } = new();

        public void AlterarDataSaida(DateTime dataSaida)
        {
            DataSaida = dataSaida;
        }

        public void AlterarDataRetornoEfetiva(DateTime dataRetornoEfetiva)
        {
            DataRetornoEfetiva = dataRetornoEfetiva;
        }

        public void IncluirPassageiro(Passageiro passageiro)
        {
            Passageiros.Add(passageiro);
        }

        public bool RemoverPassageiro(Passageiro passageiro)
        {
            return Passageiros.Remove(passageiro);
        }

        public bool EhValido()
            => (Id != 0 || DataRetornoEfetiva == DateTime.MinValue)
               && Titulo != null
               && Embarcacao != null
               && DataSaida != DateTime.MinValue
               && DataRetornoPrevista != DateTime.MinValue
               && !string.IsNullOrEmpty(Destino)
               && Responsavel != null
               && Responsavel.EhValido()
               && Passageiros.All(p => p.EhValido());
    }
}

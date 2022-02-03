using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Secretaria.Entities;

namespace IateClubManager.Infra.Data.MockDataBase
{
    internal static class FakeDataBase
    {
        internal static List<Titulo> Titulos = new();
        internal static List<Socio> Socios = new();
        internal static List<Embarcacao> Embarcacoes = new();
        internal static List<Pessoa> Pessoas = new();
        internal static List<PlanoNavegacao> PlanosNavegacoes = new();
        internal static List<Passageiro> Passageiros = new();
        internal static List<Pagamento> Pagamentos = new();
        internal static List<Advertencia> Advertencias = new();
    }
}

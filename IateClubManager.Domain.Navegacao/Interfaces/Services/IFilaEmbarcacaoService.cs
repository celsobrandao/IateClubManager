using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Domain.Navegacao.Interfaces.Services
{
    public interface IFilaEmbarcacaoService
    {
        void AtualizarFila(PlanoNavegacao planoNavegacao);
        void EntrarNaFila(PlanoNavegacao planoNavegacao);
        PlanoNavegacao LiberarProximaEmbarcacao();
        void Remover(PlanoNavegacao planoNavegacao);
        bool ValidarFila(PlanoNavegacao planoNavegacao);
    }
}
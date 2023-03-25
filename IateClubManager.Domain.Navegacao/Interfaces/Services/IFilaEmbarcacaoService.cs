using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Domain.Navegacao.Interfaces.Services
{
    public interface IFilaEmbarcacaoService
    {
        PlanoNavegacao ListarPorId(int id);
        SortedList<DateTime, PlanoNavegacao> ListarTodos();
        bool EntrarNaFila(PlanoNavegacao planoNavegacao);
        bool Remover(PlanoNavegacao planoNavegacao);
        PlanoNavegacao LiberarProximaEmbarcacao();
        PlanoNavegacao CederPosicao(PlanoNavegacao planoNavegacao);
        void AtualizarFila(PlanoNavegacao planoNavegacao);
        bool ValidarFila(PlanoNavegacao planoNavegacao);
    }
}
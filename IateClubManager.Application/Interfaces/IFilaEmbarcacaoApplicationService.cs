using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Application.Interfaces
{
    internal interface IFilaEmbarcacaoApplicationService
    {
        void AtualizarFila(PlanoNavegacao planoNavegacao);
        PlanoNavegacao? CederPosicao(PlanoNavegacao planoNavegacao);
        bool EntrarNaFila(PlanoNavegacao planoNavegacao);
        PlanoNavegacao? LiberarProximaEmbarcacao();
        PlanoNavegacao? ListarPorId(int id);
        SortedList<DateTime, PlanoNavegacao> ListarTodos();
        bool Remover(PlanoNavegacao planoNavegacao);
    }
}
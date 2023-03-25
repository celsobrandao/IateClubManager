using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Application.Interfaces
{
    public interface IPlanoNavegacaoApplicationService
    {
        bool Salvar(PlanoNavegacao planoNavegacao);
        PlanoNavegacao ListarPorId(int id);
        IEnumerable<PlanoNavegacao> ListarTodos();
        bool Remover(PlanoNavegacao titulo);
    }
}
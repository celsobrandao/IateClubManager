using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Domain.Navegacao.Services
{
    public interface IPlanoNavegacaoService
    {
        IEnumerable<PlanoNavegacao> ListarTodos();
        PlanoNavegacao ListarPorId(int id);
        public bool Salvar(PlanoNavegacao planoNavegacao);
        public bool Remover(PlanoNavegacao planoNavegacao);
    }
}
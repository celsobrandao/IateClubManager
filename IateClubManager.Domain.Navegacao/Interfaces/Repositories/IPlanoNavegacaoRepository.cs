using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Domain.Navegacao.Interfaces.Repositories
{
    public interface IPlanoNavegacaoRepository
    {
        IEnumerable<PlanoNavegacao> List();
        PlanoNavegacao? GetById(int id);
        public bool Save(PlanoNavegacao planoNavegacao);
        public bool Remove(PlanoNavegacao planoNavegacao);
    }
}
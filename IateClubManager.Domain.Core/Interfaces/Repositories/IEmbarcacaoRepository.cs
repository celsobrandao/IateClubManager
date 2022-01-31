using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Domain.Core
{
    public interface IEmbarcacaoRepository
    {
        IEnumerable<Embarcacao> List();
        Embarcacao? GetById(int id);
        bool Save(Embarcacao embarcacao);
        bool Remove(Embarcacao embarcacao);
    }
}
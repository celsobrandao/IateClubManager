using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Domain.Navegacao.Interfaces.Repositories
{
    public interface IPassageiroRepository
    {
        IEnumerable<Passageiro> List();
        Passageiro GetById(int id);
        bool Save(Passageiro passageiro);
        bool Remove(Passageiro passageiro);
    }
}
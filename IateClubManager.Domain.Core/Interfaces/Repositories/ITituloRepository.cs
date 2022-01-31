using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Domain.Core
{
    public interface ITituloRepository
    {
        IEnumerable<Titulo> List();
        Titulo? GetById(int id);
        bool Save(Titulo titulo);
        bool Remove(Titulo titulo);
    }
}
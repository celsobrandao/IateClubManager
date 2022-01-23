using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Domain.Core
{
    public interface ITituloRepository
    {
        IEnumerable<Titulo> List();
        bool Save(Titulo titulo);
        bool Remove(int id);
    }
}
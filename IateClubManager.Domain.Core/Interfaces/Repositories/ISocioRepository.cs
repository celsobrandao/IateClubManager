using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Domain.Core
{
    public interface ISocioRepository
    {
        IEnumerable<Socio> List();
        Socio GetById(int id);
        bool Save(Socio socio);
        bool Remove(Socio socio);
    }
}
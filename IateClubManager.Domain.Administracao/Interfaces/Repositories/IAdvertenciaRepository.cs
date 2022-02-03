using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Secretaria.Entities;

namespace IateClubManager.Domain.Secretaria.Interfaces.Repositories
{
    public interface IAdvertenciaRepository
    {
        bool Save(Advertencia advertencia);
        bool TemAdvertenciaEmVigenciaNaData(Socio socio, DateTime data);
    }
}
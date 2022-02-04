using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Secretaria.Entities;
using IateClubManager.Domain.Secretaria.Interfaces.Repositories;
using IateClubManager.Infra.Data.MockDataBase;

namespace IateClubManager.Infra.Data
{
    public class AdvertenciaRepository : IAdvertenciaRepository
    {
        public IEnumerable<Advertencia> List()
            => FakeDataBase.Advertencias;

        public Advertencia? GetById(int id)
            => FakeDataBase.Advertencias.Where(t => t.Id == id).FirstOrDefault();

        public bool Remove(Advertencia advertencia)
        {
            if (advertencia == null)
            {
                return false;
            }
            FakeDataBase.Advertencias.Remove(advertencia);
            return true;
        }

        public bool Save(Advertencia advertencia)
        {
            if (advertencia.Id == 0)
            {
                return Insert(advertencia);
            }
            return Update(advertencia);
        }

        private bool Insert(Advertencia advertencia)
        {
            var maxId = FakeDataBase.Advertencias.Any() ? FakeDataBase.Advertencias.Max(t => t.Id) : 0;
            advertencia.Id = maxId++;
            FakeDataBase.Advertencias.Add(advertencia);
            return true;
        }

        private bool Update(Advertencia advertencia)
        {
            var existente = GetById(advertencia.Id);
            if (existente != null)
            {
                FakeDataBase.Advertencias.Remove(existente);
                FakeDataBase.Advertencias.Add(advertencia);
                return true;
            }
            return false;
        }

        public bool TemAdvertenciaEmVigenciaNaData(Socio socio, DateTime data)
            => FakeDataBase.Advertencias.Count(t => t.Socio.Id == socio.Id && t.DataVigencia >= data) > 0;
    }
}
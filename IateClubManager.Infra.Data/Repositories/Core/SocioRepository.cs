using IateClubManager.Domain.Core;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Infra.Data.MockDataBase;

namespace IateClubManager.Infra.Data
{
    public class SocioRepository : ISocioRepository
    {
        public IEnumerable<Socio> List()
            => FakeDataBase.Socios;

        public Socio? GetById(int id)
            => FakeDataBase.Socios.Where(t => t.Id == id).FirstOrDefault();

        public bool Remove(Socio socio)
        {
            if (socio == null)
            {
                return false;
            }
            FakeDataBase.Socios.Remove(socio);
            return true;
        }

        public bool Save(Socio socio)
        {
            if (socio.Id == 0)
            {
                return Insert(socio);
            }
            return Update(socio);
        }

        private bool Insert(Socio socio)
        {
            var maxId = FakeDataBase.Socios.Any() ? FakeDataBase.Socios.Max(t => t.Id) : 0;
            socio.Id = maxId++;
            FakeDataBase.Socios.Add(socio);
            return true;
        }

        private bool Update(Socio socio)
        {
            var existente = GetById(socio.Id);
            if (existente != null)
            {
                FakeDataBase.Socios.Remove(existente);
                FakeDataBase.Socios.Add(socio);
                return true;
            }
            return false;
        }
    }
}
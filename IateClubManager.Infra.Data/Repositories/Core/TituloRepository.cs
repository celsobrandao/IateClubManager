using IateClubManager.Domain.Core;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Infra.Data.MockDataBase;

namespace IateClubManager.Infra.Data
{
    public class TituloRepository : ITituloRepository
    {
        public IEnumerable<Titulo> List()
            => FakeDataBase.Titulos;

        public Titulo GetById(int id)
            => FakeDataBase.Titulos.Where(t => t.Id == id).FirstOrDefault();

        public bool Remove(Titulo titulo)
        {
            if (titulo == null)
            {
                return false;
            }
            FakeDataBase.Titulos.Remove(titulo);
            return true;
        }

        public bool Save(Titulo titulo)
        {
            if (titulo.Id == 0)
            {
                return Insert(titulo);
            }
            return Update(titulo);
        }

        private bool Insert(Titulo titulo)
        {
            var maxId = FakeDataBase.Titulos.Any() ? FakeDataBase.Titulos.Max(t => t.Id) : 0;
            titulo.Id = maxId++;
            FakeDataBase.Titulos.Add(titulo);
            return true;
        }

        private bool Update(Titulo titulo)
        {
            var existente = GetById(titulo.Id);
            if (existente != null)
            {
                FakeDataBase.Titulos.Remove(existente);
                FakeDataBase.Titulos.Add(titulo);
                return true;
            }
            return false;
        }
    }
}
using IateClubManager.Domain.Core;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Infra.Data.MockDataBase;

namespace IateClubManager.Infra.Data
{
    public class TituloRepository : ITituloRepository
    {
        public IEnumerable<Titulo> List() 
            => TituloTable.Titulos;

        public Titulo? GetById(int id)
            => GetTitulo(id);

        public bool Remove(int id)
        {
            var titulo = GetTitulo(id);
            if (titulo == null)
            {
                return false;
            }
            TituloTable.Titulos.Remove(titulo);
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

        public static Titulo? GetTitulo(int id) 
            => TituloTable.Titulos.Where(t => t.Id == id).FirstOrDefault();

        private static bool Insert(Titulo titulo)
        {
            var maxId = TituloTable.Titulos.Max(t => t.Id);
            titulo.Id = maxId++;
            TituloTable.Titulos.Add(titulo);
            return true;
        }

        private static bool Update(Titulo titulo)
        {
            var tituloExistente = GetTitulo(titulo.Id);
            if (tituloExistente != null)
            {
                TituloTable.Titulos.Remove(tituloExistente);
                TituloTable.Titulos.Add(titulo);
                return true;
            }
            return false;
        }
    }
}
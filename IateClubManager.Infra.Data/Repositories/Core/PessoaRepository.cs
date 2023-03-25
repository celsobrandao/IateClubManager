using IateClubManager.Domain.Core;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Infra.Data.MockDataBase;

namespace IateClubManager.Infra.Data
{
    public class PessoaRepository : IPessoaRepository
    {
        public IEnumerable<Pessoa> List()
            => FakeDataBase.Pessoas;

        public Pessoa GetById(int id)
            => FakeDataBase.Pessoas.Where(t => t.Id == id).FirstOrDefault();

        public bool Remove(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return false;
            }
            FakeDataBase.Pessoas.Remove(pessoa);
            return true;
        }

        public bool Save(Pessoa pessoa)
        {
            if (pessoa.Id == 0)
            {
                return Insert(pessoa);
            }
            return Update(pessoa);
        }

        private bool Insert(Pessoa pessoa)
        {
            var maxId = FakeDataBase.Pessoas.Any() ? FakeDataBase.Pessoas.Max(t => t.Id) : 0;
            pessoa.Id = maxId++;
            FakeDataBase.Pessoas.Add(pessoa);
            return true;
        }

        private bool Update(Pessoa pessoa)
        {
            var existente = GetById(pessoa.Id);
            if (existente != null)
            {
                FakeDataBase.Pessoas.Remove(existente);
                FakeDataBase.Pessoas.Add(pessoa);
                return true;
            }
            return false;
        }
    }
}
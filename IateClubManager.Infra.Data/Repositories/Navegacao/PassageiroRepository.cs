using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Interfaces.Repositories;
using IateClubManager.Infra.Data.MockDataBase;

namespace IateClubManager.Infra.Data.Repositories.Navegacao
{
    public class PassageiroRepository : IPassageiroRepository
    {
        public IEnumerable<Passageiro> List()
            => FakeDataBase.Passageiros;

        public Passageiro GetById(int id)
            => FakeDataBase.Passageiros.FirstOrDefault(p => p.Id == id);

        public bool Remove(Passageiro passageiro)
        {
            if (passageiro == null)
            {
                return false;
            }
            FakeDataBase.Passageiros.Remove(passageiro);
            return true;
        }

        public bool Save(Passageiro passageiro)
        {
            if (passageiro.Id == 0)
            {
                return Insert(passageiro);
            }
            return Update(passageiro);
        }

        private bool Insert(Passageiro passageiro)
        {
            var maxId = FakeDataBase.Passageiros.Any() ? FakeDataBase.Passageiros.Max(t => t.Id) : 0;
            passageiro.Id = maxId++;
            FakeDataBase.Passageiros.Add(passageiro);
            return true;
        }

        private bool Update(Passageiro passageiro)
        {
            var existente = GetById(passageiro.Id);
            if (existente != null)
            {
                FakeDataBase.Passageiros.Remove(existente);
                FakeDataBase.Passageiros.Add(passageiro);
                return true;
            }
            return false;
        }
    }
}

using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Interfaces.Repositories;
using IateClubManager.Infra.Data.MockDataBase;

namespace IateClubManager.Infra.Data.Repositories.Navegacao
{
    public class PlanoNavegacaoRepository : IPlanoNavegacaoRepository
    {
        public IEnumerable<PlanoNavegacao> List()
            => FakeDataBase.PlanosNavegacoes;

        public PlanoNavegacao? GetById(int id)
            => FakeDataBase.PlanosNavegacoes.FirstOrDefault(pn => pn.Id == id);

        public bool Remove(PlanoNavegacao planoNavegacao)
        {
            if (planoNavegacao == null)
            {
                return false;
            }
            FakeDataBase.PlanosNavegacoes.Remove(planoNavegacao);
            return true;
        }

        public bool Save(PlanoNavegacao planoNavegacao)
        {
            if (planoNavegacao.Id == 0)
            {
                return Insert(planoNavegacao);
            }
            return Update(planoNavegacao);
        }

        private bool Insert(PlanoNavegacao planoNavegacao)
        {
            var maxId = FakeDataBase.PlanosNavegacoes.Any() ? FakeDataBase.PlanosNavegacoes.Max(t => t.Id) : 0;
            planoNavegacao.Id = maxId++;
            FakeDataBase.PlanosNavegacoes.Add(planoNavegacao);
            return true;
        }

        private bool Update(PlanoNavegacao planoNavegacao)
        {
            var existente = GetById(planoNavegacao.Id);
            if (existente != null)
            {
                FakeDataBase.PlanosNavegacoes.Remove(existente);
                FakeDataBase.PlanosNavegacoes.Add(planoNavegacao);
                return true;
            }
            return false;
        }
    }
}

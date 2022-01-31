using IateClubManager.Domain.Core;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Infra.Data.MockDataBase;

namespace IateClubManager.Infra.Data
{
    public class EmbarcacaoRepository : IEmbarcacaoRepository
    {
        public IEnumerable<Embarcacao> List()
            => FakeDataBase.Embarcacoes;

        public Embarcacao? GetById(int id)
            => FakeDataBase.Embarcacoes.Where(t => t.Id == id).FirstOrDefault();

        public bool Remove(Embarcacao embarcacao)
        {
            if (embarcacao == null)
            {
                return false;
            }
            FakeDataBase.Embarcacoes.Remove(embarcacao);
            return true;
        }

        public bool Save(Embarcacao embarcacao)
        {
            if (embarcacao.Id == 0)
            {
                return Insert(embarcacao);
            }
            return Update(embarcacao);
        }

        private bool Insert(Embarcacao embarcacao)
        {
            var maxId = FakeDataBase.Embarcacoes.Max(t => t.Id);
            embarcacao.Id = maxId++;
            FakeDataBase.Embarcacoes.Add(embarcacao);
            return true;
        }

        private bool Update(Embarcacao embarcacao)
        {
            var existente = GetById(embarcacao.Id);
            if (existente != null)
            {
                FakeDataBase.Embarcacoes.Remove(existente);
                FakeDataBase.Embarcacoes.Add(embarcacao);
                return true;
            }
            return false;
        }
    }
}
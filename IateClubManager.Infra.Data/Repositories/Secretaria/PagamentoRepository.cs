using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Secretaria.Entities;
using IateClubManager.Domain.Secretaria.Interfaces.Repositories;
using IateClubManager.Infra.Data.MockDataBase;

namespace IateClubManager.Infra.Data
{
    public class PagamentoRepository : IPagamentoRepository
    {
        public IEnumerable<Pagamento> List()
            => FakeDataBase.Pagamentos;

        public Pagamento GetById(int id)
            => FakeDataBase.Pagamentos.Where(t => t.Id == id).FirstOrDefault();

        public bool Remove(Pagamento pagamento)
        {
            if (pagamento == null)
            {
                return false;
            }
            FakeDataBase.Pagamentos.Remove(pagamento);
            return true;
        }

        public bool Save(Pagamento pagamento)
        {
            if (pagamento.Id == 0)
            {
                return Insert(pagamento);
            }
            return Update(pagamento);
        }

        private bool Insert(Pagamento pagamento)
        {
            var maxId = FakeDataBase.Pagamentos.Any() ? FakeDataBase.Pagamentos.Max(t => t.Id) : 0;
            pagamento.Id = maxId++;
            FakeDataBase.Pagamentos.Add(pagamento);
            return true;
        }

        private bool Update(Pagamento pagamento)
        {
            var existente = GetById(pagamento.Id);
            if (existente != null)
            {
                FakeDataBase.Pagamentos.Remove(existente);
                FakeDataBase.Pagamentos.Add(pagamento);
                return true;
            }
            return false;
        }

        public int NumeroDePagamentosNaoPagos(Socio socio)
            => FakeDataBase.Pagamentos.Count(t => t.Socio.Id == socio.Id && t.Pago == false);
    }
}
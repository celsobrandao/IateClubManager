using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Secretaria.Entities;

namespace IateClubManager.Domain.Secretaria.Interfaces.Repositories
{
    public interface IPagamentoRepository
    {
        bool Save(Pagamento pagamento);
        int NumeroDePagamentosNaoPagos(Socio socio);
    }
}
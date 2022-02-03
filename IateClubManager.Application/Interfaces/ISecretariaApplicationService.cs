using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Secretaria.Entities;

namespace IateClubManager.Application.Interfaces
{
    public interface ISecretariaApplicationService
    {
        bool SalvarPagamento(Pagamento pagamento);
        bool SalvarAdvertencia(Advertencia advertencia);
        bool SocioPodeNavegarNaData(Socio socio, DateTime data);
    }
}

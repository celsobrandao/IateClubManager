using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Secretaria.Entities;

namespace IateClubManager.Domain.Secretaria.Interfaces.Services
{
    public interface ISecretariaService
    {
        bool SalvarPagamento(Pagamento pagamento);
        bool SalvarAdvertencia(Advertencia advertencia);
        bool SocioPodeNavegarNaData(Socio socio, DateTime data);
    }
}

using IateClubManager.Application.Interfaces;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Secretaria.Entities;
using IateClubManager.Domain.Secretaria.Interfaces.Services;

namespace IateClubManager.Application
{
    public class SecretariaApplicationService : ISecretariaApplicationService
    {
        private readonly ISecretariaService _secretariaService;

        public SecretariaApplicationService(ISecretariaService secretariaService)
        {
            _secretariaService = secretariaService;
        }

        public bool SalvarAdvertencia(Advertencia advertencia)
        {
            return _secretariaService.SalvarAdvertencia(advertencia);
        }

        public bool SalvarPagamento(Pagamento pagamento)
        {
            return _secretariaService.SalvarPagamento(pagamento);
        }

        public bool SocioPodeNavegarNaData(Socio socio, DateTime data)
        {
            return _secretariaService.SocioPodeNavegarNaData(socio, data);
        }
    }
}
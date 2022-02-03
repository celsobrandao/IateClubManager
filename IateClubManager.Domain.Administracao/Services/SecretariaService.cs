using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Secretaria.Entities;
using IateClubManager.Domain.Secretaria.Interfaces.Repositories;

namespace IateClubManager.Domain.Secretaria.Interfaces.Services
{
    public class SecretariaService : ISecretariaService
    {
        private const byte MaxMesesNaoPagosParaNavegar = 3;

        private readonly IAdvertenciaRepository _advertenciaRepository;
        private readonly IPagamentoRepository _pagamentoRepository;

        public SecretariaService(IAdvertenciaRepository advertenciaRepository, IPagamentoRepository pagamentoRepository)
        {
            _advertenciaRepository = advertenciaRepository;
            _pagamentoRepository = pagamentoRepository;
        }

        public bool SalvarPagamento(Pagamento pagamento)
        {
            return _pagamentoRepository.Save(pagamento);
        }

        public bool SalvarAdvertencia(Advertencia advertencia)
        {
            return _advertenciaRepository.Save(advertencia);
        }

        public bool SocioPodeNavegarNaData(Socio socio, DateTime data)
        {
            return _advertenciaRepository.TemAdvertenciaEmVigenciaNaData(socio, data) == false &&
                   _pagamentoRepository.NumeroDePagamentosNaoPagos(socio) <= MaxMesesNaoPagosParaNavegar;
        }
    }
}

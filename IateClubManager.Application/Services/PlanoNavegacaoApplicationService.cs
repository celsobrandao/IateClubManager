using IateClubManager.Application.Interfaces;
using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Services;
using IateClubManager.Domain.Secretaria.Interfaces.Services;

namespace IateClubManager.Application.Services
{
    public class PlanoNavegacaoApplicationService : IPlanoNavegacaoApplicationService
    {
        private readonly IPlanoNavegacaoService _planoNavegacaoService;
        private readonly ISecretariaService _secretariaService;

        public PlanoNavegacaoApplicationService(IPlanoNavegacaoService planoNavegacaoService,
                                                ISecretariaService secretariaService)
        {
            _planoNavegacaoService = planoNavegacaoService;
            _secretariaService = secretariaService;
        }

        public bool Salvar(PlanoNavegacao planoNavegacao)
        {
            if (planoNavegacao.EhValido() && _secretariaService.SocioPodeNavegarNaData(planoNavegacao.Titulo.Socio, planoNavegacao.DataSaida))
            {
                return _planoNavegacaoService.Salvar(planoNavegacao);
            }
            return false;
        }

        public PlanoNavegacao? ListarPorId(int id)
        {
            return _planoNavegacaoService.ListarPorId(id);
        }

        public IEnumerable<PlanoNavegacao> ListarTodos()
        {
            return _planoNavegacaoService.ListarTodos();
        }

        public bool Remover(PlanoNavegacao titulo)
        {
            return _planoNavegacaoService.Remover(titulo);
        }
    }
}

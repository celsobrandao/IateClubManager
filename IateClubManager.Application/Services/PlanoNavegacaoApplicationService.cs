using IateClubManager.Application.Interfaces;
using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Services;

namespace IateClubManager.Application.Services
{
    public class PlanoNavegacaoApplicationService : IPlanoNavegacaoApplicationService
    {
        private readonly IPlanoNavegacaoService _planoNavegacaoService;

        public PlanoNavegacaoApplicationService(IPlanoNavegacaoService planoNavegacaoService)
        {
            _planoNavegacaoService = planoNavegacaoService;
        }

        public bool Salvar(PlanoNavegacao planoNavegacao)
        {
            if (planoNavegacao.EhValido())
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

        //public bool AlterarDataSaida(PlanoNavegacao planoNavegacao, DateTime dataSaida)
        //{
        //    return _planoNavegacaoService.AlterarDataSaida(planoNavegacao, dataSaida);
        //}

        //public bool IncluirDataRetornoEfetiva(PlanoNavegacao planoNavegacao, DateTime dataRetorno)
        //{
        //    return _planoNavegacaoService.IncluirDataRetornoEfetiva(planoNavegacao, dataRetorno);
        //}

        //public bool IncluirPassageiro(PlanoNavegacao planoNavegacao, Passageiro passageiro)
        //{
        //    return _planoNavegacaoService.IncluirPassageiro(planoNavegacao, passageiro);
        //}

        //public bool RemoverPassageiro(PlanoNavegacao planoNavegacao, Passageiro passageiro)
        //{
        //    return _planoNavegacaoService.RemoverPassageiro(planoNavegacao, passageiro);
        //}
    }
}

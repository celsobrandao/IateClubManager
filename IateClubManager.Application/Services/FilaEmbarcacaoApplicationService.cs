using IateClubManager.Application.Interfaces;
using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Interfaces.Services;

namespace IateClubManager.Application.Services
{
    public class FilaEmbarcacaoApplicationService : IFilaEmbarcacaoApplicationService
    {
        private readonly IFilaEmbarcacaoService _filaEmbarcacaoService;

        public FilaEmbarcacaoApplicationService(IFilaEmbarcacaoService filaEmbarcacaoService)
        {
            _filaEmbarcacaoService = filaEmbarcacaoService;
        }

        public PlanoNavegacao? ListarPorId(int id)
        {
            return _filaEmbarcacaoService.ListarPorId(id);
        }

        public SortedList<DateTime, PlanoNavegacao> ListarTodos()
        {
            return _filaEmbarcacaoService.ListarTodos();
        }

        public bool EntrarNaFila(PlanoNavegacao planoNavegacao)
        {
            return _filaEmbarcacaoService.EntrarNaFila(planoNavegacao);
        }

        public bool Remover(PlanoNavegacao planoNavegacao)
        {
            return _filaEmbarcacaoService.Remover(planoNavegacao);
        }

        public PlanoNavegacao? LiberarProximaEmbarcacao()
        {
            return _filaEmbarcacaoService.LiberarProximaEmbarcacao();
        }

        public PlanoNavegacao? CederPosicao(PlanoNavegacao planoNavegacao)
        {
            return _filaEmbarcacaoService.CederPosicao(planoNavegacao);
        }

        public void AtualizarFila(PlanoNavegacao planoNavegacao)
        {
            _filaEmbarcacaoService.AtualizarFila(planoNavegacao);
        }
    }
}

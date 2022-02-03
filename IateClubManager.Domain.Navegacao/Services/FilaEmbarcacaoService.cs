using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Interfaces.Services;

namespace IateClubManager.Domain.Navegacao.Services
{
    public class FilaEmbarcacaoService : IFilaEmbarcacaoService
    {
        private readonly IPlanoNavegacaoService _planoNavegacaoService;
        private SortedList<DateTime, PlanoNavegacao> _fila;

        private SortedList<DateTime, PlanoNavegacao> Fila
        {
            get
            {
                if (_fila == null)
                {
                    _fila = new SortedList<DateTime, PlanoNavegacao>(_planoNavegacaoService.ListarTodos().ToDictionary(pn => pn.DataSaida, pn => pn));
                }
                return _fila;
            }
        }

        public FilaEmbarcacaoService(IPlanoNavegacaoService planoNavegacaoService)
        {
            _planoNavegacaoService = planoNavegacaoService;
        }

        public void EntrarNaFila(PlanoNavegacao planoNavegacao)
        {
            Fila.Add(planoNavegacao.DataSaida, planoNavegacao);
        }

        public void Remover(PlanoNavegacao planoNavegacao)
        {
            var key = Fila.FirstOrDefault(pn => pn.Value.Id == planoNavegacao.Id).Key;
            Fila.Remove(key);
        }

        public PlanoNavegacao LiberarProximaEmbarcacao()
        {
            var planoNavegacao = Fila.FirstOrDefault().Value;
            Fila.RemoveAt(0);
            return planoNavegacao;
        }

        public void AtualizarFila(PlanoNavegacao planoNavegacao)
        {
            Remover(planoNavegacao);
            EntrarNaFila(planoNavegacao);
        }

        public bool ValidarFila(PlanoNavegacao planoNavegacao)
        {
            return !Fila.ContainsKey(planoNavegacao.DataSaida);
        }
    }
}

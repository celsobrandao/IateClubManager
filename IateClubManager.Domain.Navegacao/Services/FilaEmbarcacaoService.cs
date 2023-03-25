using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Interfaces.Services;
using IateClubManager.Domain.Secretaria.Interfaces.Services;

namespace IateClubManager.Domain.Navegacao.Services
{
    public class FilaEmbarcacaoService : IFilaEmbarcacaoService
    {
        private readonly IPlanoNavegacaoService _planoNavegacaoService;
        private readonly ISecretariaService _secretariaService;
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

        public FilaEmbarcacaoService(IPlanoNavegacaoService planoNavegacaoService,
                                     ISecretariaService secretariaService)
        {
            _planoNavegacaoService = planoNavegacaoService;
            _secretariaService = secretariaService;
        }

        public PlanoNavegacao ListarPorId(int id)
        {
            return Fila.FirstOrDefault(f => f.Value.Id == id).Value;
        }

        public SortedList<DateTime, PlanoNavegacao> ListarTodos()
        {
            return Fila;
        }

        public bool EntrarNaFila(PlanoNavegacao planoNavegacao)
        {
            if (_secretariaService.SocioPodeNavegarNaData(planoNavegacao.Titulo.Socio, planoNavegacao.DataSaida))
            {
                Fila.Add(planoNavegacao.DataSaida, planoNavegacao);
                return true;
            }
            return false;
        }

        public bool Remover(PlanoNavegacao planoNavegacao)
        {
            return Fila.Remove(planoNavegacao.DataSaida);
        }

        public PlanoNavegacao LiberarProximaEmbarcacao()
        {
            if (!Fila.Any())
            {
                return null;
            }

            var planoNavegacao = Fila.FirstOrDefault().Value;
            Fila.RemoveAt(0);
            return planoNavegacao;
        }

        public PlanoNavegacao CederPosicao(PlanoNavegacao planoNavegacao)
        {
            var posicao = Fila.IndexOfKey(planoNavegacao.DataSaida);
            if (posicao > Fila.Count - 1)
            {
                return null;
            }

            var proximo = Fila.Values[posicao + 1];
            var dataSaidaProximo = proximo.DataSaida;

            proximo.DataSaida = planoNavegacao.DataSaida;
            planoNavegacao.DataSaida = dataSaidaProximo;
            AtualizarFila(planoNavegacao);
            AtualizarFila(proximo);

            return proximo;
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

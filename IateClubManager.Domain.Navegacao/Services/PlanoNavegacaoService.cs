using IateClubManager.Domain.Core;
using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Interfaces.Repositories;
using IateClubManager.Domain.Navegacao.Interfaces.Services;

namespace IateClubManager.Domain.Navegacao.Services
{
    public class PlanoNavegacaoService : IPlanoNavegacaoService
    {
        private readonly IPlanoNavegacaoRepository _planoNavegacaoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPassageiroRepository _passageiroRepository;
        private readonly IFilaEmbarcacaoService _filaEmbarcacaoService;

        public PlanoNavegacaoService(IPlanoNavegacaoRepository planoNavegacaoRepository,
                                     IPessoaRepository pessoaRepository,
                                     IPassageiroRepository passageiroRepository,
                                     IFilaEmbarcacaoService filaEmbarcacaoService)
        {
            _planoNavegacaoRepository = planoNavegacaoRepository;
            _pessoaRepository = pessoaRepository;
            _passageiroRepository = passageiroRepository;
            _filaEmbarcacaoService = filaEmbarcacaoService;
        }

        public IEnumerable<PlanoNavegacao> ListarTodos()
        {
            return _planoNavegacaoRepository.List();
        }

        public PlanoNavegacao? ListarPorId(int id)
        {
            return _planoNavegacaoRepository.GetById(id);
        }

        public bool Salvar(PlanoNavegacao planoNavegacao)
        {
            var existe = planoNavegacao.Id != 0;

            _pessoaRepository.Save(planoNavegacao.Responsavel);

            foreach (var passageiro in planoNavegacao.Passageiros)
            {
                _passageiroRepository.Save(passageiro);
            }

            if (_planoNavegacaoRepository.Save(planoNavegacao))
            {
                if (existe)
                {
                    _filaEmbarcacaoService.AtualizarFila(planoNavegacao);
                }
                else
                {
                    _filaEmbarcacaoService.EntrarNaFila(planoNavegacao);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remover(PlanoNavegacao planoNavegacao)
        {
            _pessoaRepository.Remove(planoNavegacao.Responsavel);

            foreach (var passageiro in planoNavegacao.Passageiros)
            {
                _passageiroRepository.Remove(passageiro);
            }

            _filaEmbarcacaoService.Remover(planoNavegacao);

            return _planoNavegacaoRepository.Remove(planoNavegacao);
        }
    }
}

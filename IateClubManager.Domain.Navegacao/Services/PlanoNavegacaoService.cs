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
            _pessoaRepository.Save(planoNavegacao.Responsavel);

            foreach (var passageiro in planoNavegacao.Passageiros)
            {
                _passageiroRepository.Save(passageiro);
            }

            if (_planoNavegacaoRepository.Save(planoNavegacao))
            {
                _filaEmbarcacaoService.AtualizarFila(planoNavegacao);
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

        //public bool AlterarDataSaida(PlanoNavegacao planoNavegacao, DateTime dataSaida)
        //{
        //    planoNavegacao.DataSaida = dataSaida;
        //    return _planoNavegacaoRepository.Save(planoNavegacao);
        //}

        //public bool IncluirDataRetornoEfetiva(PlanoNavegacao planoNavegacao, DateTime dataRetorno)
        //{
        //    planoNavegacao.DataRetornoEfetiva = dataRetorno;
        //    return _planoNavegacaoRepository.Save(planoNavegacao);
        //}

        //public bool IncluirPassageiro(PlanoNavegacao planoNavegacao, Passageiro passageiro)
        //{
        //    planoNavegacao.IncluirPassageiro(passageiro);
        //    return _passageiroRepository.Save(passageiro);
        //}

        //public bool RemoverPassageiro(PlanoNavegacao planoNavegacao, Passageiro passageiro)
        //{
        //    planoNavegacao.RemoverPassageiro(passageiro);
        //    return _passageiroRepository.Remove(passageiro);
        //}
    }
}

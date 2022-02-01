using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.Interfaces.Services;

namespace IateClubManager.Domain.Core.Services
{
    public class TituloService : ITituloService
    {
        private readonly ITituloRepository _tituloRepository;
        private readonly ISocioRepository _socioRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IEmbarcacaoRepository _embarcacaoRepository;

        public TituloService(ITituloRepository tituloRepository,
                             ISocioRepository socioRepository,
                             IPessoaRepository pessoaRepository,
                             IEmbarcacaoRepository embarcacaoRepository)
        {
            _tituloRepository = tituloRepository;
            _socioRepository = socioRepository;
            _pessoaRepository = pessoaRepository;
            _embarcacaoRepository = embarcacaoRepository;
        }

        public Titulo? ListarPorId(int id)
        {
            return _tituloRepository.GetById(id);
        }

        public IEnumerable<Titulo> ListarTodos()
        {
            return _tituloRepository.List();
        }

        public bool Salvar(Titulo titulo)
        {
            foreach (var embarcacao in titulo.Embarcacoes)
            {
                _embarcacaoRepository.Save(embarcacao);
            }

            foreach (var pessoa in titulo.Socio.Dependentes)
            {
                _pessoaRepository.Save(pessoa);
            }

            foreach (var pessoa in titulo.Socio.Tripulantes)
            {
                _pessoaRepository.Save(pessoa);
            }

            return _tituloRepository.Save(titulo);
        }

        public bool Remover(Titulo titulo)
        {
            foreach (var embarcacao in titulo.Embarcacoes)
            {
                _embarcacaoRepository.Remove(embarcacao);
            }

            foreach (var pessoa in titulo.Socio.Dependentes)
            {
                _pessoaRepository.Remove(pessoa);
            }

            foreach (var pessoa in titulo.Socio.Tripulantes)
            {
                _pessoaRepository.Remove(pessoa);
            }

            _socioRepository.Remove(titulo.Socio);

            return _tituloRepository.Remove(titulo);
        }
    }
}


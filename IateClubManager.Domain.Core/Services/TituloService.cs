using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.Interfaces.Services;

namespace IateClubManager.Domain.Core.Services
{
    public class TituloService : ITituloService
    {
        private readonly ITituloRepository _tituloRepository;

        public TituloService(ITituloRepository tituloRepository)
        {
            _tituloRepository = tituloRepository;
        }

        public Titulo? ListarPorId(int id)
        {
            return _tituloRepository.GetById(id);
        }

        public IEnumerable<Titulo> ListarTodos()
        {
            return _tituloRepository.List();
        }

        public bool Remover(int id)
        {
            return _tituloRepository.Remove(id);
        }

        public bool Salvar(Titulo titulo)
        {
            return _tituloRepository.Save(titulo);
        }
    }
}

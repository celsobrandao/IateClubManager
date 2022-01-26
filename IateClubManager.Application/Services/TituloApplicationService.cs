using IateClubManager.Application.Interfaces;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.Interfaces.Services;

namespace IateClubManager.Application
{
    public class TituloApplicationService : ITituloApplicationService
    {
        private readonly ITituloService _tituloService;

        public TituloApplicationService(ITituloService tituloService)
        {
            _tituloService = tituloService;
        }

        public bool Salvar(Titulo titulo)
        {
           return _tituloService.Salvar(titulo);
        }

        public Titulo? ListarPorId(int id)
        {
            return _tituloService.ListarPorId(id);
        }

        public IEnumerable<Titulo> ListarTodos()
        {
            return _tituloService.ListarTodos();
        }

        public bool Remover(int id)
        {
            return _tituloService.Remover(id);
        }
    }
}
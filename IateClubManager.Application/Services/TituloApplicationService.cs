using IateClubManager.Application.Interfaces;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.Interfaces.Services;

namespace IateClubManager.Application.Services
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
            if (titulo.EhValido())
            {
                return _tituloService.Salvar(titulo);
            }
            return false;
        }

        public Titulo? ListarPorId(int id)
        {
            return _tituloService.ListarPorId(id);
        }

        public IEnumerable<Titulo> ListarTodos()
        {
            return _tituloService.ListarTodos();
        }

        public bool Remover(Titulo titulo)
        {
            return _tituloService.Remover(titulo);
        }
    }
}
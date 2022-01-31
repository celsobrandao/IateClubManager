using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Application.Interfaces
{
    public interface ITituloApplicationService
    {
        bool Salvar(Titulo titulo);
        Titulo? ListarPorId(int id);
        IEnumerable<Titulo> ListarTodos();
        bool Remover(Titulo titulo);
    }
}

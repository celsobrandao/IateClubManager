using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Domain.Core.Interfaces.Services
{
    public interface ITituloService
    {
        IEnumerable<Titulo> ListarTodos();
        Titulo ListarPorId(int id);
        bool Salvar(Titulo titulo);
        bool Remover(Titulo titulo);
    }
}

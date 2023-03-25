using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Domain.Core
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> List();
        Pessoa GetById(int id);
        bool Save(Pessoa pessoa);
        bool Remove(Pessoa pessoa);
    }
}
using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Application.Interfaces
{
    public interface IPlanoNavegacaoApplicationService
    {
        bool Salvar(PlanoNavegacao planoNavegacao);
        PlanoNavegacao? ListarPorId(int id);
        IEnumerable<PlanoNavegacao> ListarTodos();
        bool Remover(PlanoNavegacao titulo);
        //public bool AlterarDataSaida(PlanoNavegacao planoNavegacao, DateTime dataSaida);
        //public bool IncluirDataRetornoEfetiva(PlanoNavegacao planoNavegacao, DateTime dataRetorno);
        //public bool IncluirPassageiro(PlanoNavegacao planoNavegacao, Passageiro passageiro);
        //public bool RemoverPassageiro(PlanoNavegacao planoNavegacao, Passageiro passageiro);
    }
}
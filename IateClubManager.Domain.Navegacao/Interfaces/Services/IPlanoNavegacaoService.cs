using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Domain.Navegacao.Services
{
    public interface IPlanoNavegacaoService
    {
        IEnumerable<PlanoNavegacao> ListarTodos();
        PlanoNavegacao? ListarPorId(int id);
        public bool Salvar(PlanoNavegacao planoNavegacao);
        public bool Remover(PlanoNavegacao planoNavegacao);
        //public bool AlterarDataSaida(PlanoNavegacao planoNavegacao, DateTime dataSaida);
        //public bool IncluirDataRetornoEfetiva(PlanoNavegacao planoNavegacao, DateTime dataRetorno);
        //public bool IncluirPassageiro(PlanoNavegacao planoNavegacao, Passageiro passageiro);
        //public bool RemoverPassageiro(PlanoNavegacao planoNavegacao, Passageiro passageiro);
    }
}
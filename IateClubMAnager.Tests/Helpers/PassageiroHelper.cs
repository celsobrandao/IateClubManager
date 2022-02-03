using IateClubManager.Domain.Navegacao.Entities;

namespace IateClubManager.Tests.Helpers
{
    internal static class PassageiroHelper
    {
        internal static Passageiro MontePassageiro()
        {
            return new Passageiro
            {
                Id = RandomHelper.GetInt(),
                Nome = RandomHelper.GetString(),
                Telefone = RandomHelper.GetString()
            };
        }
    }
}
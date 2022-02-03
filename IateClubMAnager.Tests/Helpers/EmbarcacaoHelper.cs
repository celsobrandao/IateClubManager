using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Tests.Helpers
{
    internal static class EmbarcacaoHelper
    {

        internal static Embarcacao MonteEmbarcacao()
        {
            return new Embarcacao
            {
                Id = RandomHelper.GetInt(),
                Nome = RandomHelper.GetString(),
                Registro = RandomHelper.GetString()
            };
        }
    }
}
using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Tests.Helpers
{
    internal static class SocioHelper
    {
        internal static Socio MonteSocio()
        {
            return new Socio
            {
                Id = RandomHelper.GetInt(),
                Pessoa = PessoaHelper.MontePessoaFisica(),
                Responsavel = PessoaHelper.MontePessoaFisica()
            };
        }
    }
}
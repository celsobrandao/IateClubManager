using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.Enums;

namespace IateClubManager.Tests.Helpers
{
    internal static class PessoaHelper
    {
        internal static Pessoa MontePessoaFisica()
        {
            return new Pessoa
            {
                Id = RandomHelper.GetInt(),
                CPFCNPJ = RandomHelper.GetString(11),
                TipoPessoa = TipoPessoaEnum.PF,
                Nome = RandomHelper.GetString(20)
            };
        }

        internal static Pessoa MontePessoaJuridica()
        {
            return new Pessoa
            {
                Id = RandomHelper.GetInt(),
                CPFCNPJ = RandomHelper.GetString(14),
                TipoPessoa = TipoPessoaEnum.PJ,
                Nome = RandomHelper.GetString(30)
            };
        }
    }
}
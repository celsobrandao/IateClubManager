using FluentAssertions;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.Enums;
using IateClubManager.Tests.Helpers;
using Xunit;

namespace IateClubManager.Tests.Domain.Core.Entities
{
    public class PessoaTests
    {
        [Theory]
        [InlineData("123456789xz", TipoPessoaEnum.PF)]
        [InlineData("123456789xz123", TipoPessoaEnum.PJ)]
        public void CpfCnpjEhValido_deve_retornar_true_quando_codigo_de_acordo_com_tipo(string cpfCnpj, TipoPessoaEnum tipo)
        {
            var pessoa = new Pessoa
            {
                Id = RandomHelper.GetInt(),
                TipoPessoa = tipo,
                CPFCNPJ = cpfCnpj
            };
            var actual = pessoa.CpfCnpjEhValido();
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData("123456789", TipoPessoaEnum.PF)]
        [InlineData("123456789123456789", TipoPessoaEnum.PF)]
        [InlineData("", TipoPessoaEnum.PF)]
        [InlineData(null, TipoPessoaEnum.PF)]
        [InlineData("123456789xz123123456789xz123", TipoPessoaEnum.PJ)]
        [InlineData("123456789", TipoPessoaEnum.PJ)]
        [InlineData("", TipoPessoaEnum.PJ)]
        [InlineData(null, TipoPessoaEnum.PJ)]
        public void CpfCnpjEhValido_deve_retornar_false_quando_codigo_invalido(string cpfCnpj, TipoPessoaEnum tipo)
        {
            var pessoa = new Pessoa
            {
                Id = RandomHelper.GetInt(),
                TipoPessoa = tipo,
                CPFCNPJ = cpfCnpj
            };
            var actual = pessoa.CpfCnpjEhValido();
            actual.Should().BeFalse();
        }
    }
}
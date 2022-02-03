using FluentAssertions;
using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Tests.Helpers;
using Xunit;

namespace IateClubManager.Tests.Domain.Navegacao.Entities
{
    public class PassageiroTests
    {
        [Fact]
        public void EhValida_deve_retornar_true_quando_nome_e_telefone_estiverem_preenchidos()
        {
            var passageiro = new Passageiro
            {
                Id = RandomHelper.GetInt(),
                Nome = RandomHelper.GetString(),
                Telefone = RandomHelper.GetString()
            };
            var actual = passageiro.EhValido();
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData(null, "telefone")]
        [InlineData("nome", null)]
        [InlineData(null, null)]
        public void EhValida_deve_retornar_false_quando_nome_e_ou_telefone_nao_estiverem_preenchidos(string? nome, string? telefone)
        {
            var passageiro = new Passageiro
            {
                Id = RandomHelper.GetInt(),
                Nome = nome,
                Telefone = telefone
            };
            var actual = passageiro.EhValido();
            actual.Should().BeFalse();
        }
    }
}
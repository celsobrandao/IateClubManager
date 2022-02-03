using FluentAssertions;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Tests.Helpers;
using Xunit;

namespace IateClubManager.Tests.Domain.Core.Entities
{
    public class EmbarcacaoTests
    {
        [Fact]
        public void EhValida_deve_retornar_true_quando_nome_e_registro_estiverem_preenchidos()
        {
            var embarcacao = new Embarcacao
            {
                Id = RandomHelper.GetInt(),
                Nome = RandomHelper.GetString(),
                Registro = RandomHelper.GetString()
            };
            var actual = embarcacao.EhValido();
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData(null, "registro")]
        [InlineData("nome", null)]
        [InlineData(null, null)]
        public void EhValida_deve_retornar_false_quando_nome_e_ou_registro_nao_estiverem_preenchidos(string? nome, string? registro)
        {
            var embarcacao = new Embarcacao
            {
                Id = RandomHelper.GetInt(),
                Nome = nome,
                Registro = registro
            };
            var actual = embarcacao.EhValido();
            actual.Should().BeFalse();
        }
    }
}
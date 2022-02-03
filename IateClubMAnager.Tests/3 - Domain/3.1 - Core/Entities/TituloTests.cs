using FluentAssertions;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Tests.Helpers;
using System.Linq;
using Xunit;

namespace IateClubMAnager.Tests.Domain.Core.Entities
{
    public class TituloTests
    {
        private const byte MaxEmbarcacoes = 2;

        [Fact]
        public void AlterarSocio_deve_setar_socio_conforme_esperado()
        {
            var titulo = new Titulo();
            titulo.Socio.Should().BeNull();

            var socio = SocioHelper.MonteSocio();
            titulo.AlterarSocio(socio);

            titulo.Socio.Should().BeEquivalentTo(socio);
        }

        [Fact]
        public void AdicionarEmbarcacao_deve_adicionar_embarcacao_conforme_esperado()
        {
            var titulo = new Titulo();
            titulo.Embarcacoes.Should().BeEmpty();

            var embarcacao = EmbarcacaoHelper.MonteEmbarcacao();
            titulo.AdicionarEmbarcacao(embarcacao);

            titulo.Embarcacoes.First().Should().BeEquivalentTo(embarcacao);
        }

        [Fact]
        public void AdicionarEmbarcacao_nao_deve_adicionar_mais_embarcacoes_que_o_limite_maximo()
        {
            var titulo = new Titulo();
            for (int i = 0; i < MaxEmbarcacoes; i++)
            {
                var embarcacaoOK = EmbarcacaoHelper.MonteEmbarcacao();
                var actualOK = titulo.AdicionarEmbarcacao(embarcacaoOK);
                actualOK.Should().BeTrue(because: "dentro do limite");
            }

            var embarcacaoExtra = EmbarcacaoHelper.MonteEmbarcacao();
            var actualExtra = titulo.AdicionarEmbarcacao(embarcacaoExtra);
            actualExtra.Should().BeFalse(because: "acima do limite");
        }

        [Fact]
        public void AdicionarEmbarcacao_nao_deve_adicionar_embarcacao_duplicada()
        {
            var titulo = new Titulo();
            var embarcacao = EmbarcacaoHelper.MonteEmbarcacao();

            var actual = titulo.AdicionarEmbarcacao(embarcacao);
            actual.Should().BeTrue(because: "embarcacao única");

            actual = titulo.AdicionarEmbarcacao(embarcacao);
            actual.Should().BeFalse(because: "embarcacao duplicada");
        }

        [Fact]
        public void EhValido_deve_retornar_true_quando_tiver_socio_valido_e_todas_as_embarcacoes_validas()
        {
            var titulo = TituloHelper.MonteTitulo();

            var actual = titulo.EhValido();
            actual.Should().BeTrue();
        }

        [Fact]
        public void EhValido_deve_retornar_false_quando_nao_tiver_socio_valido()
        {
            var titulo = TituloHelper.MonteTitulo();
            var socioInvalido = (Socio) null;

            titulo.AlterarSocio(socioInvalido);

            var actual = titulo.EhValido();
            actual.Should().BeFalse();
        }

        [Fact]
        public void EhValido_deve_retornar_false_quando_nao_tiver_todas_as_embarcacoes_validas()
        {
            var titulo = TituloHelper.MonteTitulo();
            var embarcacaoInvalida = new Embarcacao { Id = RandomHelper.GetInt() };

            titulo.AdicionarEmbarcacao(embarcacaoInvalida);

            var actual = titulo.EhValido();
            actual.Should().BeFalse();
        }

    }
}
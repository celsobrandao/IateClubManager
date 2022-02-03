using FluentAssertions;
using IateClubManager.Domain.Core.Entities;
using IateClubMAnager.Tests.Helpers;
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
            var socio = new Socio
            {
                Id = RandomHelper.GetInt(),
                Pessoa = new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = IateClubManager.Domain.Core.Enums.TipoPessoaEnum.PJ },
                Responsavel = new Pessoa { Id = RandomHelper.GetInt() }
            };
            var titulo = new Titulo();
            titulo.Socio.Should().BeNull();

            titulo.AlterarSocio(socio);

            titulo.Socio.Should().BeEquivalentTo(socio);
        }

        [Fact]
        public void AdicionarEmbarcacao_deve_adicionar_embarcacao_conforme_esperado()
        {
            var embarcacao = new Embarcacao
            {
                Id = RandomHelper.GetInt(),
                Nome = RandomHelper.GetString(),
                Registro = RandomHelper.GetString()
            };
            var titulo = new Titulo();
            titulo.Embarcacoes.Should().BeEmpty();

            titulo.AdicionarEmbarcacao(embarcacao);

            titulo.Embarcacoes.First().Should().BeEquivalentTo(embarcacao);
        }

        [Fact]
        public void AdicionarEmbarcacao_nao_deve_adicionar_mais_embarcacoes_que_o_limite_maximo()
        {
            var titulo = new Titulo();
            for (int i = 0; i < MaxEmbarcacoes; i++)
            {
                var embarcacaoOK = new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() };
                var actualOK = titulo.AdicionarEmbarcacao(embarcacaoOK);
                actualOK.Should().BeTrue(because: "dentro do limite");
            }

            var embarcacaoExtra = new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() };
            var actualExtra = titulo.AdicionarEmbarcacao(embarcacaoExtra);
            actualExtra.Should().BeFalse(because: "acima do limite");
        }

        [Fact]
        public void AdicionarEmbarcacao_nao_deve_adicionar_embarcacao_duplicada()
        {
            var titulo = new Titulo();
            var embarcacao = new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() };

            var actual = titulo.AdicionarEmbarcacao(embarcacao);
            actual.Should().BeTrue(because: "embarcacao única");

            actual = titulo.AdicionarEmbarcacao(embarcacao);
            actual.Should().BeFalse(because: "embarcacao duplicada");
        }

        [Fact]
        public void EhValido_deve_retornar_true_quando_tiver_socio_valido_e_todas_as_embarcacoes_validas()
        {
            var titulo = new Titulo();
            var socioValido = new Socio { Id = RandomHelper.GetInt(), Pessoa = new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = IateClubManager.Domain.Core.Enums.TipoPessoaEnum.PJ }, Responsavel = new Pessoa { Id = RandomHelper.GetInt() } };
            var embarcacaoValida = new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() };
            var embarcacaoValida2 = new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() };

            titulo.AlterarSocio(socioValido);
            titulo.AdicionarEmbarcacao(embarcacaoValida);
            titulo.AdicionarEmbarcacao(embarcacaoValida2);

            var actual = titulo.EhValido();
            actual.Should().BeTrue();
        }

        [Fact]
        public void EhValido_deve_retornar_false_quando_nao_tiver_socio_valido()
        {
            var titulo = new Titulo();
            var socioInvalido = (Socio) null;
            var embarcacaoValida = new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() };
            var embarcacaoValida2 = new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() };

            titulo.AlterarSocio(socioInvalido);
            titulo.AdicionarEmbarcacao(embarcacaoValida);
            titulo.AdicionarEmbarcacao(embarcacaoValida2);

            var actual = titulo.EhValido();
            actual.Should().BeFalse();
        }

        [Fact]
        public void EhValido_deve_retornar_false_quando_nao_tiver_todas_as_embarcacoes_validas()
        {
            var titulo = new Titulo();
            var socioValido = new Socio { Id = RandomHelper.GetInt(), Pessoa = new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = IateClubManager.Domain.Core.Enums.TipoPessoaEnum.PJ }, Responsavel = new Pessoa { Id = RandomHelper.GetInt() } };
            var embarcacaoValida = new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() };
            var embarcacaoInvalida = new Embarcacao { Id = RandomHelper.GetInt() };

            titulo.AlterarSocio(socioValido);
            titulo.AdicionarEmbarcacao(embarcacaoValida);
            titulo.AdicionarEmbarcacao(embarcacaoInvalida);

            var actual = titulo.EhValido();
            actual.Should().BeFalse();
        }

    }
}
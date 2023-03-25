using FluentAssertions;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.ValueObjects;
using IateClubManager.Tests.Helpers;
using Xunit;

namespace IateClubManager.Tests.Domain.Core.Entities
{
    public class SocioTests
    {
        private const byte MaxDependentes = 4;
        private const byte MaxTripulantes = 2;

        [Fact]
        public void EhValido_deve_retornar_true_quando_for_PJ_e_tiver_responsavel()
        {
            var socio = new Socio
            {
                Id = RandomHelper.GetInt(),
                Pessoa = new Pessoa { Id = RandomHelper.GetInt(), CPFCNPJ = new CpfCnpj(RandomHelper.GetString(14)), TipoPessoa = IateClubManager.Domain.Core.Enums.TipoPessoaEnum.PJ, Nome = RandomHelper.GetString() },
                Responsavel = new Pessoa { Id = RandomHelper.GetInt(), CPFCNPJ = new CpfCnpj(RandomHelper.GetString(11)), TipoPessoa = IateClubManager.Domain.Core.Enums.TipoPessoaEnum.PF, Nome = RandomHelper.GetString() }
            };
            var actual = socio.EhValido();
            actual.Should().BeTrue();
        }

        [Fact]
        public void EhValido_deve_retornar_false_quando_for_PJ_e_nao_tiver_responsavel()
        {
            var socio = new Socio
            {
                Id = RandomHelper.GetInt(),
                Pessoa = new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = IateClubManager.Domain.Core.Enums.TipoPessoaEnum.PJ }
            };
            var actual = socio.EhValido();
            actual.Should().BeFalse();
        }

        [Fact]
        public void EhValido_deve_retornar_false_quando_nao_tiver_pessoa()
        {
            var socio = new Socio
            {
                Id = RandomHelper.GetInt()
            };
            var actual = socio.EhValido();
            actual.Should().BeFalse();
        }

        [Fact]
        public void AdicionarDependente_nao_deve_adicionar_mais_dependentes_que_o_limite_maximo()
        {
            var socio = new Socio { Id = RandomHelper.GetInt() };
            for (int i = 0; i < MaxDependentes; i++)
            {
                var pessoaOK = new Pessoa { Id = RandomHelper.GetInt() };
                var actualOK = socio.AdicionarDependente(pessoaOK);
                actualOK.Should().BeTrue(because: "dentro do limite");
            }

            var pessoaExtra = new Pessoa { Id = RandomHelper.GetInt() };
            var actualExtra = socio.AdicionarDependente(pessoaExtra);
            actualExtra.Should().BeFalse(because: "acima do limite");
        }

        [Fact]
        public void AdicionarTripulante_nao_deve_adicionar_mais_tripulantes_que_o_limite_maximo()
        {
            var socio = new Socio { Id = RandomHelper.GetInt() };
            for (int i = 0; i < MaxTripulantes; i++)
            {
                var pessoaOK = new Pessoa { Id = RandomHelper.GetInt() };
                var actualOK = socio.AdicionarTripulante(pessoaOK);
                actualOK.Should().BeTrue(because: "dentro do limite");
            }

            var pessoaExtra = new Pessoa { Id = RandomHelper.GetInt() };
            var actualExtra = socio.AdicionarTripulante(pessoaExtra);
            actualExtra.Should().BeFalse(because: "acima do limite");
        }
    }
}
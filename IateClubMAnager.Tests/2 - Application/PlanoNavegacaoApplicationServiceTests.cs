using FluentAssertions;
using IateClubManager.Application.Services;
using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Services;
using IateClubManager.Domain.Secretaria.Interfaces.Services;
using IateClubManager.Infra.Data;
using IateClubManager.Tests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IateClubManager.Tests.Application.Services
{
    public class PlanoNavegacaoApplicationServiceTests
    {
        private Mock<IPlanoNavegacaoService> _planoNavegacaoService;
        private PlanoNavegacaoApplicationService _applicationService;
        private SecretariaApplicationService _secretariaApplicationService;

        public PlanoNavegacaoApplicationServiceTests()
        {
            _planoNavegacaoService = new Mock<IPlanoNavegacaoService>();
            _planoNavegacaoService.Setup(pns => pns.Remover(It.IsAny<PlanoNavegacao>()));

            var secretariaService = new SecretariaService(new AdvertenciaRepository(), new PagamentoRepository());

            _applicationService = new PlanoNavegacaoApplicationService(_planoNavegacaoService.Object, secretariaService);
            _secretariaApplicationService = new SecretariaApplicationService(secretariaService);
        }

        [Fact]
        public void ListarTodos_deve_chamar_servico()
        {
            _applicationService.ListarTodos();

            _planoNavegacaoService.Verify(pns => pns.ListarTodos(), Times.Once);
        }

        [Fact]
        public void ListarTodos_deve_retornar_dados_do_servico()
        {
            var expected = new List<PlanoNavegacao>
            {
                PlanoNavegacaoHelper.MontePlanoNavegacao(),
                PlanoNavegacaoHelper.MontePlanoNavegacao(),
                PlanoNavegacaoHelper.MontePlanoNavegacao()
            };
            _planoNavegacaoService.Setup(pns => pns.ListarTodos()).Returns(expected);

            var actual = _applicationService.ListarTodos();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ListarPorId_deve_chamar_servico()
        {
            var id = RandomHelper.GetInt();
            _applicationService.ListarPorId(id);

            _planoNavegacaoService.Verify(pns => pns.ListarPorId(id), Times.Once);
        }

        [Fact]
        public void ListarPorId_deve_retornar_dados_do_servico()
        {
            var expected = PlanoNavegacaoHelper.MontePlanoNavegacao();

            _planoNavegacaoService.Setup(pns => pns.ListarPorId(expected.Id)).Returns(expected);

            var actual = _applicationService.ListarPorId(expected.Id);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Salvar_deve_chamar_servico_quando_planoNavegacao_for_valido()
        {
            var planoNavegacaoValido = PlanoNavegacaoHelper.MontePlanoNavegacaoValidoComPagamentosEAdvertenciaPassada(_secretariaApplicationService, _applicationService);

            _planoNavegacaoService.Verify(pns => pns.Salvar(It.IsAny<PlanoNavegacao>()), Times.Once);
        }

        [Fact]
        public void Salvar_deve_chamar_servico_somente_se_planoNavegacao_for_valido()
        {
            var planoNavegacaoInvalido = PlanoNavegacaoHelper.MontePlanoNavegacaoInvalidoSemPagamentosEAdvertenciaVigente(_secretariaApplicationService, _applicationService);

            _planoNavegacaoService.Verify(pns => pns.Salvar(It.IsAny<PlanoNavegacao>()), Times.Never);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Salvar_deve_retornar_resposta_do_servico(bool expected)
        {
            var planoNavegacao = PlanoNavegacaoHelper.MontePlanoNavegacao();

            _planoNavegacaoService.Setup(pns => pns.Salvar(planoNavegacao)).Returns(expected);

            var actual = _applicationService.Salvar(planoNavegacao);

            actual.Should().Be(expected);
        }

        [Fact]
        public void Remover_deve_chamar_servico()
        {
            var planoNavegacao = PlanoNavegacaoHelper.MontePlanoNavegacao();

            _applicationService.Remover(planoNavegacao);

            _planoNavegacaoService.Verify(pns => pns.Remover(planoNavegacao), Times.Once);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Remover_deve_retornar_resposta_do_servico(bool expected)
        {
            var planoNavegacao = PlanoNavegacaoHelper.MontePlanoNavegacao();

            _planoNavegacaoService.Setup(pns => pns.Remover(planoNavegacao)).Returns(expected);

            var actual = _applicationService.Remover(planoNavegacao);

            actual.Should().Be(expected);
        }

        [Fact]
        public void AlterarDataSaida_Salvar_deve_chamar_servico_quando_planoNavegacao_for_valido()
        {
            var planoNavegacao = PlanoNavegacaoHelper.MontePlanoNavegacao();
            var data = DateTime.Now;

            planoNavegacao.AlterarDataSaida(data);

            _applicationService.Salvar(planoNavegacao);

            _planoNavegacaoService.Verify(pns => pns.Salvar(It.IsAny<PlanoNavegacao>()), Times.Once);
        }

        [Fact]
        public void AlterarDataRetornoEfetiva_Salvar_deve_chamar_servico_somente_se_planoNavegacao_for_valido()
        {
            var planoNavegacao = PlanoNavegacaoHelper.MontePlanoNavegacao();
            var data = DateTime.Now;

            planoNavegacao.AlterarDataRetornoEfetiva(data);

            _applicationService.Salvar(planoNavegacao);

            _planoNavegacaoService.Verify(pns => pns.Salvar(It.IsAny<PlanoNavegacao>()), Times.Never);
        }
    }
}
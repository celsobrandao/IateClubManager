using FluentAssertions;
using IateClubManager.Application.Services;
using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Domain.Navegacao.Interfaces.Services;
using IateClubManager.Domain.Navegacao.Services;
using IateClubManager.Domain.Secretaria.Interfaces.Services;
using IateClubManager.Infra.Data;
using IateClubManager.Infra.Data.Repositories.Navegacao;
using IateClubManager.Tests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IateClubManager.Tests.Application.Services
{
    public class FilaEmbarcacaoApplicationServiceTests
    {
        private Mock<IFilaEmbarcacaoService> _filaEmbarcacaoService;
        private FilaEmbarcacaoApplicationService _applicationService;
        private PlanoNavegacaoApplicationService _planoNavegacaoApplicationService;
        private SecretariaApplicationService _secretariaApplicationService;

        public FilaEmbarcacaoApplicationServiceTests()
        {
            _filaEmbarcacaoService = new Mock<IFilaEmbarcacaoService>();
            _filaEmbarcacaoService.Setup(fes => fes.Remover(It.IsAny<PlanoNavegacao>()));

            var planoNavegacaoService = new PlanoNavegacaoService(new PlanoNavegacaoRepository(), new PessoaRepository(), new PassageiroRepository(), _filaEmbarcacaoService.Object);
            var secretariaService = new SecretariaService(new AdvertenciaRepository(), new PagamentoRepository());

            _applicationService = new FilaEmbarcacaoApplicationService(_filaEmbarcacaoService.Object);
            _planoNavegacaoApplicationService = new PlanoNavegacaoApplicationService(planoNavegacaoService, secretariaService);
            _secretariaApplicationService = new SecretariaApplicationService(secretariaService);
        }

        [Fact]
        public void ListarTodos_deve_chamar_servico()
        {
            _applicationService.ListarTodos();

            _filaEmbarcacaoService.Verify(fes => fes.ListarTodos(), Times.Once);
        }

        [Fact]
        public void ListarTodos_deve_retornar_dados_do_servico()
        {
            var dataBase = DateTime.Now;

            var expected = new SortedList<DateTime, PlanoNavegacao>
            {
                { dataBase.AddHours(1), PlanoNavegacaoHelper.MontePlanoNavegacao(DateTime.Now) },
                { dataBase.AddHours(2), PlanoNavegacaoHelper.MontePlanoNavegacao(DateTime.Now.AddHours(1)) },
                { dataBase.AddHours(3),  PlanoNavegacaoHelper.MontePlanoNavegacao(DateTime.Now.AddHours(2)) }
            };
            _filaEmbarcacaoService.Setup(fes => fes.ListarTodos()).Returns(expected);

            var actual = _applicationService.ListarTodos();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ListarPorId_deve_chamar_servico()
        {
            var id = RandomHelper.GetInt();
            _applicationService.ListarPorId(id);

            _filaEmbarcacaoService.Verify(fes => fes.ListarPorId(id), Times.Once);
        }

        [Fact]
        public void ListarPorId_deve_retornar_dados_do_servico()
        {
            var expected = PlanoNavegacaoHelper.MontePlanoNavegacao();

            _filaEmbarcacaoService.Setup(fes => fes.ListarPorId(expected.Id)).Returns(expected);

            var actual = _applicationService.ListarPorId(expected.Id);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void EntrarNaFila_deve_chamar_servico_quando_planoNavegacao_for_valido()
        {
            var planoNavegacaoValido = PlanoNavegacaoHelper.MontePlanoNavegacaoValidoComPagamentosEAdvertenciaPassada(_secretariaApplicationService, _planoNavegacaoApplicationService);

            _filaEmbarcacaoService.Verify(fes => fes.EntrarNaFila(It.IsAny<PlanoNavegacao>()), Times.Once);
        }

        [Fact]
        public void EntrarNaFila_deve_chamar_servico_somente_se_planoNavegacao_for_valido()
        {
            var planoNavegacaoInvalido = PlanoNavegacaoHelper.MontePlanoNavegacaoInvalidoSemPagamentosEAdvertenciaVigente(_secretariaApplicationService, _planoNavegacaoApplicationService);

            _filaEmbarcacaoService.Verify(fes => fes.EntrarNaFila(It.IsAny<PlanoNavegacao>()), Times.Never);
        }

        [Fact]
        public void Remover_deve_chamar_servico()
        {
            var planoNavegacao = PlanoNavegacaoHelper.MontePlanoNavegacao();

            _applicationService.Remover(planoNavegacao);

            _filaEmbarcacaoService.Verify(fes => fes.Remover(planoNavegacao), Times.Once);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Remover_deve_retornar_resposta_do_servico(bool expected)
        {
            var planoNavegacao = PlanoNavegacaoHelper.MontePlanoNavegacao();

            _filaEmbarcacaoService.Setup(fes => fes.Remover(planoNavegacao)).Returns(expected);

            var actual = _applicationService.Remover(planoNavegacao);

            actual.Should().Be(expected);
        }

        [Fact]
        public void LiberarProximaEmbarcacao_deve_retornar_dados_do_servico()
        {
            var expected = PlanoNavegacaoHelper.MontePlanoNavegacao();
            expected.AlterarDataSaida(DateTime.Now.AddHours(1));
            _applicationService.EntrarNaFila(expected);

            var planoNavegacao = PlanoNavegacaoHelper.MontePlanoNavegacao();
            planoNavegacao.AlterarDataSaida(DateTime.Now.AddHours(2));
            _applicationService.EntrarNaFila(planoNavegacao);

            _filaEmbarcacaoService.Setup(fes => fes.LiberarProximaEmbarcacao()).Returns(expected);

            var actual = _applicationService.LiberarProximaEmbarcacao();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CederPosicao_deve_retornar_dados_do_servico()
        {
            var planoNavegacao = PlanoNavegacaoHelper.MontePlanoNavegacao();
            planoNavegacao.AlterarDataSaida(DateTime.Now.AddHours(1));
            _applicationService.EntrarNaFila(planoNavegacao);

            var expected = PlanoNavegacaoHelper.MontePlanoNavegacao();
            expected.AlterarDataSaida(DateTime.Now.AddHours(2));
            _applicationService.EntrarNaFila(expected);

            _filaEmbarcacaoService.Setup(fes => fes.CederPosicao(planoNavegacao)).Returns(expected);

            var actual = _applicationService.CederPosicao(planoNavegacao);

            actual.Should().BeEquivalentTo(expected);
        }

    }
}

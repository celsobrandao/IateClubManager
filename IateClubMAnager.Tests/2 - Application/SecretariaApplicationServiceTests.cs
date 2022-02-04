using FluentAssertions;
using IateClubManager.Application.Services;
using IateClubManager.Domain.Secretaria.Interfaces.Services;
using IateClubManager.Tests.Helpers;
using Moq;
using System;
using Xunit;

namespace IateClubManager.Tests.Application.Services
{
    public class SecretariaApplicationServiceTests
    {
        private Mock<ISecretariaService> _secretariaServiceMock;
        private SecretariaApplicationService _secretariaApplicationService;

        public SecretariaApplicationServiceTests()
        {
            _secretariaServiceMock = new Mock<ISecretariaService>();

            _secretariaApplicationService = new SecretariaApplicationService(_secretariaServiceMock.Object);
        }

        [Fact]
        public void SalvarAdvertencia_deve_chamar_servico()
        {

            var advertencia = AdvertenciaHelper.MonteAdvertenciaPassada();

            _secretariaServiceMock.Setup(s => s.SalvarAdvertencia(advertencia)).Returns(true);

            var actual = _secretariaApplicationService.SalvarAdvertencia(advertencia);

            _secretariaServiceMock.Verify(s => s.SalvarAdvertencia(advertencia), Times.Once);

            actual.Should().BeTrue();
        }

        [Fact]
        public void SalvarPagamento_deve_chamar_servico()
        {
            var pagamento = PagamentoHelper.MontePagamento();

            _secretariaServiceMock.Setup(s => s.SalvarPagamento(pagamento)).Returns(true);

            var actual = _secretariaApplicationService.SalvarPagamento(pagamento);

            _secretariaServiceMock.Verify(s => s.SalvarPagamento(pagamento), Times.Once);

            actual.Should().BeTrue();
        }

        [Fact]
        public void SocioPodeNavegarNaData_deve_chamar_servico()
        {
            var socio = SocioHelper.MonteSocio();
            var data = DateTime.Now;

            _secretariaServiceMock.Setup(s => s.SocioPodeNavegarNaData(socio, data)).Returns(true);

            var actual = _secretariaApplicationService.SocioPodeNavegarNaData(socio, data);

            _secretariaServiceMock.Verify(s => s.SocioPodeNavegarNaData(socio, data), Times.Once);

            actual.Should().BeTrue();
        }
    }
}
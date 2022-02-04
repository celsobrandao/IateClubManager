using FluentAssertions;
using IateClubManager.Domain.Secretaria.Interfaces.Repositories;
using IateClubManager.Domain.Secretaria.Interfaces.Services;
using IateClubManager.Tests.Helpers;
using Moq;
using System;
using Xunit;

namespace IateClubMAnager.Tests.Domain.Secretaria.Services
{
    public class SecretariaServiceTests
    {
        private const byte MaxMesesNaoPagosParaNavegar = 3;

        private Mock<IAdvertenciaRepository> _advertenciaRepository;
        private Mock<IPagamentoRepository> _pagamentoRepository;

        private SecretariaService _secretariaService;

        public SecretariaServiceTests()
        {
            _advertenciaRepository = new Mock<IAdvertenciaRepository>();
            _pagamentoRepository = new Mock<IPagamentoRepository>();

            _secretariaService = new SecretariaService(_advertenciaRepository.Object,
                                                       _pagamentoRepository.Object);
        }

        [Fact]
        public void SalvarPagamento_deve_chamar_repositorio_e_retornar_conforme_esperado()
        {
            var pagamento = PagamentoHelper.MontePagamento();

            _pagamentoRepository.Setup(p => p.Save(pagamento)).Returns(true);

            var actual = _secretariaService.SalvarPagamento(pagamento);

            _pagamentoRepository.Verify(p => p.Save(pagamento), Times.Once);

            actual.Should().BeTrue();
        }

        [Fact]
        public void SalvarAdvertencia_deve_chamar_repositorio_e_retornar_conforme_esperado()
        {
            var advertencia = AdvertenciaHelper.MonteAdvertenciaPassada();

            _advertenciaRepository.Setup(a => a.Save(advertencia)).Returns(true);

            var actual = _secretariaService.SalvarAdvertencia(advertencia);

            _advertenciaRepository.Verify(a => a.Save(advertencia), Times.Once);

            actual.Should().BeTrue();
        }

        [Fact]
        public void SocioPodeNavegarNaData_deve_retornar_true_quando_socio_nao_tem_pendencias()
        {
            var socio = SocioHelper.MonteSocio();
            var data = DateTime.Now;

            _advertenciaRepository.Setup(a => a.TemAdvertenciaEmVigenciaNaData(socio, data)).Returns(false);
            _pagamentoRepository.Setup(p => p.NumeroDePagamentosNaoPagos(socio)).Returns(MaxMesesNaoPagosParaNavegar);

            var actual = _secretariaService.SocioPodeNavegarNaData(socio, data);

            _advertenciaRepository.Verify(a => a.TemAdvertenciaEmVigenciaNaData(socio, data), Times.Once);
            _pagamentoRepository.Verify(p => p.NumeroDePagamentosNaoPagos(socio), Times.Once);

            actual.Should().BeTrue();
        }

        [Fact]
        public void SocioPodeNavegarNaData_deve_retornar_false_quando_socio_tem_advertencia_vigente()
        {
            var socio = SocioHelper.MonteSocio();
            var data = DateTime.Now;

            _advertenciaRepository.Setup(a => a.TemAdvertenciaEmVigenciaNaData(socio, data)).Returns(true);
            _pagamentoRepository.Setup(p => p.NumeroDePagamentosNaoPagos(socio)).Returns(MaxMesesNaoPagosParaNavegar);

            var actual = _secretariaService.SocioPodeNavegarNaData(socio, data);

            actual.Should().BeFalse();
        }

        [Fact]
        public void SocioPodeNavegarNaData_deve_retornar_false_quando_socio_tem_mais_pagamentos_pendentes_que_o_limite()
        {
            var socio = SocioHelper.MonteSocio();
            var data = DateTime.Now;

            _advertenciaRepository.Setup(a => a.TemAdvertenciaEmVigenciaNaData(socio, data)).Returns(false);
            _pagamentoRepository.Setup(p => p.NumeroDePagamentosNaoPagos(socio)).Returns(MaxMesesNaoPagosParaNavegar + 1);

            var actual = _secretariaService.SocioPodeNavegarNaData(socio, data);

            actual.Should().BeFalse();
        }
    }
}
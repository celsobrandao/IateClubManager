using FluentAssertions;
using IateClubManager.Application;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.Enums;
using IateClubManager.Domain.Core.Interfaces.Services;
using IateClubManager.Tests.Helpers;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace IateClubManager.Tests.Application.Services
{
    public class TituloApplicationServiceTests
    {
        private Mock<ITituloService> _tituloService;
        private TituloApplicationService _applicationService;

        public TituloApplicationServiceTests()
        {
            _tituloService = new Mock<ITituloService>();
            _tituloService.Setup(ts => ts.Remover(It.IsAny<Titulo>()));

            _applicationService = new TituloApplicationService(_tituloService.Object);
        }

        [Fact]
        public void ListarTodos_deve_chamar_servico()
        {
            _applicationService.ListarTodos();

            _tituloService.Verify(ts => ts.ListarTodos(), Times.Once);
        }

        [Fact]
        public void ListarTodos_deve_retornar_dados_do_servico()
        {
            var expected = new List<Titulo>
            {
                TituloHelper.MonteTitulo(),
                TituloHelper.MonteTitulo(),
                TituloHelper.MonteTitulo()
            };
            _tituloService.Setup(ts => ts.ListarTodos()).Returns(expected);

            var actual = _applicationService.ListarTodos();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ListarPorId_deve_chamar_servico()
        {
            var id = RandomHelper.GetInt();
            _applicationService.ListarPorId(id);

            _tituloService.Verify(ts => ts.ListarPorId(id), Times.Once);
        }

        [Fact]
        public void ListarPorId_deve_retornar_dados_do_servico()
        {
            var expected = TituloHelper.MonteTitulo();

            _tituloService.Setup(ts => ts.ListarPorId(expected.Id)).Returns(expected);

            var actual = _applicationService.ListarPorId(expected.Id);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Salvar_deve_chamar_servico_quando_titulo_for_valido()
        {
            var tituloValido = TituloHelper.MonteTitulo();

            _applicationService.Salvar(tituloValido);

            _tituloService.Verify(ts => ts.Salvar(It.IsAny<Titulo>()), Times.Once);
        }

        [Fact]
        public void Salvar_nao_deve_chamar_servico_se_titulo_for_invalido()
        {
            var tituloInvalido = TituloHelper.MonteTitulo();
            var socioInvalido = (Socio)null;
            tituloInvalido.AlterarSocio(socioInvalido);

            _applicationService.Salvar(tituloInvalido);

            _tituloService.Verify(ts => ts.Salvar(It.IsAny<Titulo>()), Times.Never);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Salvar_deve_retornar_resposta_do_servico(bool expected)
        {
            var titulo = TituloHelper.MonteTitulo();

            _tituloService.Setup(ts => ts.Salvar(titulo)).Returns(expected);

            var actual = _applicationService.Salvar(titulo);

            actual.Should().Be(expected);
        }

        [Fact]
        public void Remover_deve_chamar_servico()
        {
            var titulo = TituloHelper.MonteTitulo();

            _applicationService.Remover(titulo);

            _tituloService.Verify(ts => ts.Remover(titulo), Times.Once);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Remover_deve_retornar_resposta_do_servico(bool expected)
        {
            var titulo = TituloHelper.MonteTitulo();

            _tituloService.Setup(ts => ts.Remover(titulo)).Returns(expected);

            var actual = _applicationService.Remover(titulo);

            actual.Should().Be(expected);
        }
    }
}
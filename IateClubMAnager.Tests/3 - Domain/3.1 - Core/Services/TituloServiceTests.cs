using FluentAssertions;
using IateClubManager.Domain.Core;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.Enums;
using IateClubManager.Domain.Core.Services;
using IateClubMAnager.Tests.Helpers;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IateClubMAnager.Tests.Domain.Core.Services
{
    public class TituloServiceTests
    {
        private Mock<ITituloRepository> _tituloRepositoryMock;
        private Mock<ISocioRepository> _socioRepositoryMock;
        private Mock<IPessoaRepository> _pessoaRepositoryMock;
        private Mock<IEmbarcacaoRepository> _embarcacaoRepositoryMock;
        private TituloService _tituloService;

        public TituloServiceTests()
        {
            _tituloRepositoryMock = new Mock<ITituloRepository>();
            _socioRepositoryMock = new Mock<ISocioRepository>();
            _pessoaRepositoryMock = new Mock<IPessoaRepository>();
            _embarcacaoRepositoryMock = new Mock<IEmbarcacaoRepository>();

            _tituloService = new TituloService(_tituloRepositoryMock.Object,
                                               _socioRepositoryMock.Object,
                                               _pessoaRepositoryMock.Object,
                                               _embarcacaoRepositoryMock.Object);
        }

        [Fact]
        public void ListarTodos_deve_chamar_repositorio_e_retornar_conforme_esperado()
        {
            var titulosExpected = new List<Titulo>
            {
                MonteTitulo(),
                MonteTitulo(),
                MonteTitulo()
            };

            _tituloRepositoryMock.Setup(tr => tr.List()).Returns(titulosExpected);

            var actual = _tituloService.ListarTodos();

            _tituloRepositoryMock.Verify(tr => tr.List(), Times.Once);
            actual.Should().BeEquivalentTo(titulosExpected);
        }

        [Fact]
        public void ListarPorId_deve_chamar_repositorio_e_retornar_conforme_esperado()
        {
            var tituloExpected = MonteTitulo();

            _tituloRepositoryMock.Setup(tr => tr.GetById(tituloExpected.Id)).Returns(tituloExpected);

            var actual = _tituloService.ListarPorId(tituloExpected.Id);

            _tituloRepositoryMock.Verify(tr => tr.GetById(tituloExpected.Id), Times.Once);
            actual.Should().BeEquivalentTo(tituloExpected);
        }

        [Fact]
        public void Salvar_deve_chamar_repositorio_e_retornar_conforme_esperado()
        {
            var titulo = MonteTituloCompleto();

            _embarcacaoRepositoryMock.Setup(tr => tr.Save(It.IsAny<Embarcacao>())).Returns(true);
            _pessoaRepositoryMock.Setup(tr => tr.Save(It.IsAny<Pessoa>())).Returns(true);
            _socioRepositoryMock.Setup(tr => tr.Save(It.IsAny<Socio>())).Returns(true);
            _tituloRepositoryMock.Setup(tr => tr.Save(It.IsAny<Titulo>())).Returns(true);

            var actual = _tituloService.Salvar(titulo);

            _embarcacaoRepositoryMock.Verify(tr => tr.Save(It.IsAny<Embarcacao>()), Times.Exactly(2));
            _pessoaRepositoryMock.Verify(tr => tr.Save(It.IsAny<Pessoa>()), Times.Exactly(6));
            _socioRepositoryMock.Verify(tr => tr.Save(It.IsAny<Socio>()), Times.Exactly(1));
            _tituloRepositoryMock.Verify(tr => tr.Save(It.IsAny<Titulo>()), Times.Exactly(1));

            actual.Should().BeTrue();
        }

        [Fact]
        public void Remover_deve_chamar_repositorio_e_retornar_conforme_esperado()
        {
            var titulo = MonteTituloCompleto();

            _embarcacaoRepositoryMock.Setup(tr => tr.Remove(It.IsAny<Embarcacao>())).Returns(true);
            _pessoaRepositoryMock.Setup(tr => tr.Remove(It.IsAny<Pessoa>())).Returns(true);
            _socioRepositoryMock.Setup(tr => tr.Remove(It.IsAny<Socio>())).Returns(true);
            _tituloRepositoryMock.Setup(tr => tr.Remove(It.IsAny<Titulo>())).Returns(true);

            var actual = _tituloService.Remover(titulo);

            _embarcacaoRepositoryMock.Verify(tr => tr.Remove(It.IsAny<Embarcacao>()), Times.Exactly(2));
            _pessoaRepositoryMock.Verify(tr => tr.Remove(It.IsAny<Pessoa>()), Times.Exactly(6));
            _socioRepositoryMock.Verify(tr => tr.Remove(It.IsAny<Socio>()), Times.Exactly(1));
            _tituloRepositoryMock.Verify(tr => tr.Remove(It.IsAny<Titulo>()), Times.Exactly(1));

            actual.Should().BeTrue();
        }

        private Titulo MonteTitulo()
        {
            var titulo = new Titulo { Id = RandomHelper.GetInt() };
            titulo.AlterarSocio(new Socio { Id = RandomHelper.GetInt(), Pessoa = new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = TipoPessoaEnum.PF } });
            titulo.AdicionarEmbarcacao(new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() });
            titulo.AdicionarEmbarcacao(new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() });
            return titulo;
        }

        private Titulo MonteTituloCompleto()
        {
            var titulo = new Titulo { Id = RandomHelper.GetInt() };
            var socio = new Socio { Id = RandomHelper.GetInt(), Pessoa = new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = TipoPessoaEnum.PJ } };
            socio.Responsavel = new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = TipoPessoaEnum.PF };
            socio.AdicionarDependente(new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = TipoPessoaEnum.PF });
            socio.AdicionarDependente(new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = TipoPessoaEnum.PF });
            socio.AdicionarDependente(new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = TipoPessoaEnum.PF });
            socio.AdicionarDependente(new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = TipoPessoaEnum.PF });
            socio.AdicionarTripulante(new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = TipoPessoaEnum.PF });
            socio.AdicionarTripulante(new Pessoa { Id = RandomHelper.GetInt(), TipoPessoa = TipoPessoaEnum.PF });
            titulo.AlterarSocio(socio);
            titulo.AdicionarEmbarcacao(new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() });
            titulo.AdicionarEmbarcacao(new Embarcacao { Id = RandomHelper.GetInt(), Nome = RandomHelper.GetString(), Registro = RandomHelper.GetString() });
            return titulo;
        }

    }
}
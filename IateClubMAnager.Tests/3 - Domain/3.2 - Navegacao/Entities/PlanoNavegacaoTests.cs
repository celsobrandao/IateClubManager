using FluentAssertions;
using IateClubManager.Domain.Navegacao.Entities;
using IateClubManager.Tests.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace IateClubManager.Tests.Domain.Navegacao.Entities
{
    public class PlanoNavegacaoTests
    {
        public static IEnumerable<object[]> GetDadosInvalidos()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new PlanoNavegacao //Sem Titulo
                    {
                        Id = 0,
                        Titulo = null,
                        Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                        DataSaida = DateTime.Now,
                        DataRetornoPrevista = DateTime.Now,
                        DataRetornoEfetiva = DateTime.MinValue,
                        Destino = RandomHelper.GetString(),
                        Responsavel = PessoaHelper.MontePessoaFisica(),
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                },
                new object[]
                {
                    new PlanoNavegacao //Sem Embarcacao
                    {
                        Id = 0,
                        Titulo = TituloHelper.MonteTitulo(),
                        Embarcacao = null,
                        DataSaida = DateTime.Now,
                        DataRetornoPrevista = DateTime.Now,
                        DataRetornoEfetiva = DateTime.MinValue,
                        Destino = RandomHelper.GetString(),
                        Responsavel = PessoaHelper.MontePessoaFisica(),
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                },
                new object[]
                {
                    new PlanoNavegacao //Sem DataSaida
                    {
                        Id = 0,
                        Titulo = TituloHelper.MonteTitulo(),
                        Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                        DataSaida = DateTime.MinValue,
                        DataRetornoPrevista = DateTime.Now,
                        DataRetornoEfetiva = DateTime.MinValue,
                        Destino = RandomHelper.GetString(),
                        Responsavel = PessoaHelper.MontePessoaFisica(),
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                },
                new object[]
                {
                    new PlanoNavegacao //Sem DataRetornoPrevista
                    {
                        Id = 0,
                        Titulo = TituloHelper.MonteTitulo(),
                        Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                        DataSaida = DateTime.Now,
                        DataRetornoPrevista = DateTime.MinValue,
                        DataRetornoEfetiva = DateTime.MinValue,
                        Destino = RandomHelper.GetString(),
                        Responsavel = PessoaHelper.MontePessoaFisica(),
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                },
                new object[]
                {
                    new PlanoNavegacao //Sem Id e Com DataRetornoEfetiva
                    {
                        Id = 0,
                        Titulo = TituloHelper.MonteTitulo(),
                        Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                        DataSaida = DateTime.Now,
                        DataRetornoPrevista = DateTime.Now,
                        DataRetornoEfetiva = DateTime.Now,
                        Destino = RandomHelper.GetString(),
                        Responsavel = PessoaHelper.MontePessoaFisica(),
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                },
                new object[]
                {
                    new PlanoNavegacao //Sem Destino
                    {
                        Id = 0,
                        Titulo = TituloHelper.MonteTitulo(),
                        Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                        DataSaida = DateTime.Now,
                        DataRetornoPrevista = DateTime.Now,
                        DataRetornoEfetiva = DateTime.MinValue,
                        Destino = "",
                        Responsavel = PessoaHelper.MontePessoaFisica(),
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                },
                new object[]
                {
                    new PlanoNavegacao //Sem Responsavel
                    {
                        Id = 0,
                        Titulo = TituloHelper.MonteTitulo(),
                        Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                        DataSaida = DateTime.Now,
                        DataRetornoPrevista = DateTime.Now,
                        DataRetornoEfetiva = DateTime.MinValue,
                        Destino = RandomHelper.GetString(),
                        Responsavel = null,
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                }
            };
        }

        public static IEnumerable<object[]> GetDadosValidos()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new PlanoNavegacao //Sem Id e Sem DataRetornoEfetiva
                    {
                        Id = 0,
                        Titulo = TituloHelper.MonteTitulo(),
                        Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                        DataSaida = DateTime.Now,
                        DataRetornoPrevista = DateTime.Now,
                        DataRetornoEfetiva = DateTime.MinValue,
                        Destino = RandomHelper.GetString(),
                        Responsavel = PessoaHelper.MontePessoaFisica(),
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                },
                new object[]
                {
                    new PlanoNavegacao //Com Id e Sem DataRetornoEfetiva
                    {
                        Id = RandomHelper.GetInt(),
                        Titulo = TituloHelper.MonteTitulo(),
                        Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                        DataSaida = DateTime.Now,
                        DataRetornoPrevista = DateTime.Now,
                        DataRetornoEfetiva = DateTime.MinValue,
                        Destino = RandomHelper.GetString(),
                        Responsavel = PessoaHelper.MontePessoaFisica(),
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                },
                new object[]
                {
                    new PlanoNavegacao //Com Id e Com DataRetornoEfetiva
                    {
                        Id = RandomHelper.GetInt(),
                        Titulo = TituloHelper.MonteTitulo(),
                        Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                        DataSaida = DateTime.Now,
                        DataRetornoPrevista = DateTime.Now,
                        DataRetornoEfetiva = DateTime.Now,
                        Destino = RandomHelper.GetString(),
                        Responsavel = PessoaHelper.MontePessoaFisica(),
                        Passageiros = new()
                        {
                            PassageiroHelper.MontePassageiro()
                        }
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetDadosInvalidos))]
        public void PlanoNavegacaoEhValido_deve_retornar_false_quando_dados_invalidos(PlanoNavegacao planoNavegacao)
        {
            var actual = planoNavegacao.EhValido();
            actual.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(GetDadosValidos))]
        public void PlanoNavegacaoEhValido_deve_retornar_true_quando_dados_validos(PlanoNavegacao planoNavegacao)
        {
            var actual = planoNavegacao.EhValido();
            actual.Should().BeTrue();
        }
    }
}
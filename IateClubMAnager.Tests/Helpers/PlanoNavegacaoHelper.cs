using IateClubManager.Application.Services;
using IateClubManager.Domain.Navegacao.Entities;
using System;

namespace IateClubManager.Tests.Helpers
{
    internal class PlanoNavegacaoHelper
    {
        internal static PlanoNavegacao MontePlanoNavegacao()
        {
            return new PlanoNavegacao
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
            };
        }

        internal static PlanoNavegacao MontePlanoNavegacao(DateTime dataSaida)
        {
            return new PlanoNavegacao
            {
                Id = 0,
                Titulo = TituloHelper.MonteTitulo(),
                Embarcacao = EmbarcacaoHelper.MonteEmbarcacao(),
                DataSaida = dataSaida,
                DataRetornoPrevista = DateTime.Now,
                DataRetornoEfetiva = DateTime.MinValue,
                Destino = RandomHelper.GetString(),
                Responsavel = PessoaHelper.MontePessoaFisica(),
                Passageiros = new()
                {
                    PassageiroHelper.MontePassageiro()
                }
            };
        }

        internal static PlanoNavegacao MontePlanoNavegacaoValidoComPagamentosEAdvertenciaPassada(SecretariaApplicationService secretariaApplicationService, PlanoNavegacaoApplicationService planoNavegacaoApplicationService)
        {
            var planoNavegacaoValido = MontePlanoNavegacao();
            var socio = planoNavegacaoValido.Titulo.Socio;

            var pagamento = PagamentoHelper.MontePagamento(socio, DateTime.Now.AddMonths(-3), true);
            secretariaApplicationService.SalvarPagamento(pagamento);

            pagamento = PagamentoHelper.MontePagamento(socio, DateTime.Now.AddMonths(-2), true);
            secretariaApplicationService.SalvarPagamento(pagamento);

            pagamento = PagamentoHelper.MontePagamento(socio, DateTime.Now.AddMonths(-1), true);
            secretariaApplicationService.SalvarPagamento(pagamento);

            pagamento = PagamentoHelper.MontePagamento(socio, DateTime.Now, true);
            secretariaApplicationService.SalvarPagamento(pagamento);

            var advertencia = AdvertenciaHelper.MonteAdvertenciaPassada();
            secretariaApplicationService.SalvarAdvertencia(advertencia);

            planoNavegacaoApplicationService.Salvar(planoNavegacaoValido);

            return planoNavegacaoValido;
        }

        internal static PlanoNavegacao MontePlanoNavegacaoInvalidoSemPagamentosEAdvertenciaVigente(SecretariaApplicationService secretariaApplicationService, PlanoNavegacaoApplicationService planoNavegacaoApplicationService)
        {
            var planoNavegacaoInvalido = MontePlanoNavegacao();
            planoNavegacaoInvalido.Id = 0;
            planoNavegacaoInvalido.DataRetornoEfetiva = DateTime.Now;

            var advertencia = AdvertenciaHelper.MonteAdvertenciaVigente();
            secretariaApplicationService.SalvarAdvertencia(advertencia);

            planoNavegacaoApplicationService.Salvar(planoNavegacaoInvalido);

            return planoNavegacaoInvalido;
        }
    }
}

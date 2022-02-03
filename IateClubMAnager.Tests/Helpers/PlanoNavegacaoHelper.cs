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
    }
}

using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Tests.Helpers
{
    internal static class TituloHelper
    {
        internal static Titulo MonteTitulo()
        {
            var titulo = new Titulo
            {
                Id = RandomHelper.GetInt()
            };
            titulo.AlterarSocio(SocioHelper.MonteSocio());
            titulo.AdicionarEmbarcacao(EmbarcacaoHelper.MonteEmbarcacao());
            return titulo;
        }
    }
}
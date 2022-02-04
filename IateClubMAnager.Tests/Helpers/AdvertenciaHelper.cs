using IateClubManager.Domain.Secretaria.Entities;
using System;

namespace IateClubManager.Tests.Helpers
{
    internal class AdvertenciaHelper
    {
        internal static Advertencia MonteAdvertenciaVigente()
        {
            return new Advertencia
            {
                Id = RandomHelper.GetInt(),
                Socio = SocioHelper.MonteSocio(),
                DataAdvertencia = DateTime.Now.AddDays(-10),
                DataVigencia = DateTime.Now.AddDays(10)
            };
        }

        internal static Advertencia MonteAdvertenciaPassada()
        {
            return new Advertencia
            {
                Id = RandomHelper.GetInt(),
                Socio = SocioHelper.MonteSocio(),
                DataAdvertencia = DateTime.Now.AddDays(-20),
                DataVigencia = DateTime.Now.AddDays(-10)
            };
        }
    }
}

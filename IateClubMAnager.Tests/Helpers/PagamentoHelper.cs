using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Secretaria.Entities;
using System;

namespace IateClubManager.Tests.Helpers
{
    internal class PagamentoHelper
    {
        internal static Pagamento MontePagamento(Socio socio, DateTime vencimento, bool pago)
        {
            return new Pagamento
            {
                Id = RandomHelper.GetInt(),
                Socio = socio,
                DataVencimento = vencimento,
                Pago = pago,
            };
        }

        internal static Pagamento MontePagamento()
        {
            return new Pagamento
            {
                Id = RandomHelper.GetInt(),
                Socio = SocioHelper.MonteSocio(),
                DataVencimento = DateTime.Now,
                Pago = true,
            };
        }
    }
}

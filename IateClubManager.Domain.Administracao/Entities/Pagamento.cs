using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Domain.Secretaria.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public Socio Socio { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }
    }
}

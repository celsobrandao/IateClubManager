using IateClubManager.Domain.Core.Entities;

namespace IateClubManager.Domain.Secretaria.Entities
{
    public class Advertencia
    {
        public int Id { get; set; }
        public Socio Socio { get; set; }
        public DateTime DataAdvertencia { get; set; }
        public DateTime DataVigencia { get; set; }
    }
}

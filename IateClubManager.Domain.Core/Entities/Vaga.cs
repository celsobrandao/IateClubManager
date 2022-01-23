using IateClubManager.Domain.Core.Enums;

namespace IateClubManager.Domain.Core.Entities
{
    public class Vaga
    {
        public int ID { get; set; }
        public TipoVagaEnum Tipo { get; set; }
    }
}

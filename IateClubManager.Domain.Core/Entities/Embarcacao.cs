using IateClubManager.Domain.Core.Enums;

namespace IateClubManager.Domain.Core.Entities
{
    public class Embarcacao
    {
        public int ID { get; set; }
        public Vaga Vaga { get; set; } = new();
        public string? Nome { get; set; }
        public string? Registro { get; set; }
        public string? Fabricante { get; set; }
        public string? Modelo { get; set; }
        public string? Tamanho { get; set; }
        public MotorEnum Motor { get; set; }
        public CombustivelEnum Combustivel { get; set; }
    }
}

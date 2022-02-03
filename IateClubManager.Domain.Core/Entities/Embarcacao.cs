using IateClubManager.Domain.Core.Enums;

namespace IateClubManager.Domain.Core.Entities
{
    public class Embarcacao
    {
        public int Id { get; set; }
        public TipoVagaEnum? Vaga { get; set; }
        public string? Nome { get; set; }
        public string? Registro { get; set; }
        public string? Fabricante { get; set; }
        public string? Modelo { get; set; }
        public string? Tamanho { get; set; }
        public MotorEnum Motor { get; set; }
        public CombustivelEnum Combustivel { get; set; }

        public bool EhValido()
            => string.IsNullOrWhiteSpace(Nome) == false && string.IsNullOrWhiteSpace(Registro) == false;
    }
}

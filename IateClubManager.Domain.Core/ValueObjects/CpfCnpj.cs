namespace IateClubManager.Domain.Core.ValueObjects
{
    public class CpfCnpj
    {
        public CpfCnpj()
        {
        }

        public CpfCnpj(string valor)
        {
            Valor = valor ?? throw new ArgumentNullException(nameof(valor));
        }

        public string Valor { get; set; }

        public override string ToString()
        {
            return Valor;
        }
    }
}

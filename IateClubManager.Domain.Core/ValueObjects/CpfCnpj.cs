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
            if (string.IsNullOrEmpty(Valor))
                return "";
            else
            {
                if (long.TryParse(Valor, out long l))
                {
                    if (Valor.Length == 11)
                        return l.ToString(@"000\.000\.000\-00");
                    else if (Valor.Length == 14)
                        return l.ToString(@"00\.000\.000\/0000\-00");
                    else
                        return Valor;
                }
                else
                    return Valor;
            }
        }
    }
}

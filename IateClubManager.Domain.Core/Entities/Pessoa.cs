using IateClubManager.Domain.Core.Enums;

namespace IateClubManager.Domain.Core.Entities
{
    public class Pessoa
    {
        public int ID { get; set; }
        public string? CPFCNPJ { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public int Habilitacao { get; set; }
        public string? Categoria { get; set; }
        public TipoPessoaEnum TipoPessoa
        {
            get
            {
                if (CPFCNPJ?.Length == 11)
                    return TipoPessoaEnum.PF;
                else if (CPFCNPJ?.Length == 14)
                    return TipoPessoaEnum.PJ;
                else
                    return TipoPessoaEnum.Indefinido;
            }
        }
    }
}

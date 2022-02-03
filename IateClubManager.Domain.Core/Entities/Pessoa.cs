using IateClubManager.Domain.Core.Enums;

namespace IateClubManager.Domain.Core.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? CPFCNPJ { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public int Habilitacao { get; set; }
        public string? Categoria { get; set; }
        public TipoPessoaEnum? TipoPessoa { get; set; }

        public bool CpfCnpjEhValido()
        {
            switch (TipoPessoa)
            {
                case TipoPessoaEnum.PF:
                    return CPFCNPJ?.Length == 11;
                case TipoPessoaEnum.PJ:
                    return CPFCNPJ?.Length == 14;
                default:
                    return false;
            }
        }

        public bool EhValido()
            => CpfCnpjEhValido() && !string.IsNullOrEmpty(Nome);
    }
}

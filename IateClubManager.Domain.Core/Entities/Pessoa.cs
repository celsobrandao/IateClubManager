using FluentValidation;
using IateClubManager.Domain.Core.Enums;
using IateClubManager.Domain.Core.Rules;
using IateClubManager.Domain.Core.ValueObjects;

namespace IateClubManager.Domain.Core.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public CpfCnpj CPFCNPJ { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int Habilitacao { get; set; }
        public string Categoria { get; set; }
        public TipoPessoaEnum TipoPessoa { get; set; }

        public void Validar() => new PessoaValidator().ValidateAndThrow(this);

        public bool EhValido() => new PessoaValidator().Validate(this).IsValid;
    }
}

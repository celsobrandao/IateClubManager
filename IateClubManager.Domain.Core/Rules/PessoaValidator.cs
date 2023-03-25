using FluentValidation;
using IateClubManager.Domain.Core.Entities;
using IateClubManager.Domain.Core.Enums;

namespace IateClubManager.Domain.Core.Rules
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.CPFCNPJ).SetValidator(new CpfCnpjValidator());
            RuleFor(x => x).Must(TipoPessoaValido);
        }

        private bool TipoPessoaValido(Pessoa pessoa) => (pessoa.TipoPessoa == TipoPessoaEnum.PF && pessoa.CPFCNPJ?.Valor?.Length == 11) ||
                                                        (pessoa.TipoPessoa == TipoPessoaEnum.PJ && pessoa.CPFCNPJ?.Valor?.Length == 14);
    }
}

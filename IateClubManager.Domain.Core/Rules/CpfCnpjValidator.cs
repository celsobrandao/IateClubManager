using FluentValidation;
using IateClubManager.Domain.Core.ValueObjects;

namespace IateClubManager.Domain.Core.Rules
{
    public class CpfCnpjValidator : AbstractValidator<CpfCnpj>
    {
        public CpfCnpjValidator()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .Must(CpfCnpjValido)
                .WithMessage("CPF/CNPJ inválido.");
        }

        private bool CpfCnpjValido(string value)
        {
            return value?.Length is 11 or 14;
        }
    }
}

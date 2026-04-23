using FluentValidation;
using HandlingExtinguishers.Models.Credit;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidatorCredit : AbstractValidator<CreditServiceRequest>
    {
        public ValidatorCredit()
        {
            RuleFor(x => x.IdService).NotEmpty().WithMessage("El campo IdServicio deve ir con un dato valido.");
            RuleFor(x => x.Preview).NotEmpty().WithMessage("El campo Abono no puede ir vacío.");
            RuleFor(x => x.Debt).NotEmpty().WithMessage("El campo Deuda no puede ir vacío.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("El campo Fecha no puede ir vacío.");
        }
    }
}

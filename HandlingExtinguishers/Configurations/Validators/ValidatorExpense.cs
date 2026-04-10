using FluentValidation;
using ManagementFireEstinguisher.Dto.Expenses;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidatorExpense : AbstractValidator<GastosBase>
    {
        public ValidatorExpense()
        {
            RuleFor(gasto => gasto.Descripcion)
                .NotEmpty()
                .WithMessage("El campo descripcion no puede ir vacia");

            RuleFor(gasto => gasto.Fecha)
                .NotNull()
                .WithMessage("El campo fecha no puede ir vacia");

            RuleFor(gasto => gasto.Total)
                .NotEmpty()
                .WithMessage("El campo total  no puede ir vacio");
        }
    }
}

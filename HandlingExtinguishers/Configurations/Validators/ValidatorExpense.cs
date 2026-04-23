using FluentValidation;
using HandlingExtinguishers.Models.Expenses;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidatorExpense : AbstractValidator<ExpenseRequest>
    {
        public ValidatorExpense()
        {
            RuleFor(expense => expense.Description)
                .NotEmpty()
                .WithMessage("El campo descripcion no puede ir vacia");

            RuleFor(expense => expense.Date)
                .NotNull()
                .WithMessage("El campo fecha no puede ir vacia");

            RuleFor(expense => expense.Total)
                .NotEmpty()
                .WithMessage("El campo total  no puede ir vacio");
        }
    }
}

using FluentValidation;
using HandlingExtinguishers.Models.Employees;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidatorEmployee : AbstractValidator<EmployeeRequestDto>
    {
        public ValidatorEmployee()
        {
            RuleFor(x => x.CompanyId)
                .NotEmpty()
                .WithMessage("El campo companyId no puede ir vacio, y la empresa debe existir en la base de datos");

            RuleFor(x => x.FirstName)
                .NotEmpty()
            .WithMessage("El campo firstName no puede ir vacio");

            RuleFor(x => x.LastName)
                .NotEmpty()
            .WithMessage("El campo lastName no puede ir vacio");

            RuleFor(x => x.Phone)
                .NotEmpty()
            .WithMessage("El campo phone no puede ir vacia");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El campo email no puede ir vacio");
        }
    }
}

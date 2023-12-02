using FluentValidation;
using HandlingExtinguishers.Models.Company;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidatorCompany : AbstractValidator<CompanyRequestDto>
    {
        public ValidatorCompany()
        {
            RuleFor(x => x.Name).NotEmpty().
                        WithMessage("El campo nombre no puede ir vacío");

            RuleFor(x => x.Address).NotEmpty().
                  WithMessage("El campo dirección no puede ir vacío");

            RuleFor(x => x.Nit).NotEmpty().
                 WithMessage("El campo nit no puede ir vacío");
        }
    }
}

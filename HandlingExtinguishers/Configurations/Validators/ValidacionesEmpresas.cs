using FluentValidation;
using HandlingExtinguishers.Dto.Company;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidacionesEmpresas : AbstractValidator<CompanyBase>
    {
        public ValidacionesEmpresas()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El campo nombre no puede ir vacio");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("El campo direccion no puede ir vacia");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El campo email no puede ir vacio");
        }
    }
}

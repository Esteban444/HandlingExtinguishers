using FluentValidation;
using HandlingExtinguisher.Dto.Clients;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidacionClientes : AbstractValidator<BaseClient>
    {
        public ValidacionClientes()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("El campo nombre no puede ir vacio");
            RuleFor(c => c.Address).NotEmpty().WithMessage("El campo direccion no puede ir vacio");
        }
    }
}

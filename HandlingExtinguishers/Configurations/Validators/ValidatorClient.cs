using FluentValidation;
using HandlingExtinguishers.Models.Clients;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidatorClient : AbstractValidator<ClientRequest>
    {
        public ValidatorClient()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("El campo nombre no puede ir vacio");
            RuleFor(c => c.Address).NotEmpty().WithMessage("El campo direccion no puede ir vacio");
        }
    }
}

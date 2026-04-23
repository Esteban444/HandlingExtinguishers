using FluentValidation;
using HandlingExtinguishers.Models.Services;

namespace HandlingExtinguishers.Configurations.Validators
{
    class ValidatorService : AbstractValidator<ServiceRequest>
    {
        public ValidatorService()
        {
            RuleFor(s => s.IdClient).NotEmpty()
                .WithMessage("El campo cliente debe existir en la tabla clientes de la base de datos");

            RuleFor(s => s.IdEmployee).NotEmpty()
                .WithMessage("El empleado debe existir en la tabla empleados de la base de datos");

            RuleFor(s => s.ServiceDate).NotEmpty().WithMessage("El campo fechaServicio no puede ir vacio");
            RuleFor(s => s.Status).NotEmpty().WithMessage("El campo estado no puede ir vacio");
        }
    }
}

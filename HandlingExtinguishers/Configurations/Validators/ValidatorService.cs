using FluentValidation;
using ManagementFireEstinguisher.Dto.Services;

namespace HandlingExtinguishers.Configurations.Validators
{
    class ValidatorService : AbstractValidator<ServicioBase>
    {
        public ValidatorService()
        {
            RuleFor(s => s.IdClientes).NotEmpty()
                .WithMessage("El campo cliente debe existir en la tabla clientes de la base de datos");

            RuleFor(s => s.IdEmpleados).NotEmpty()
                .WithMessage("El empleado debe existir en la tabla empleados de la base de datos");

            RuleFor(s => s.FechaServicio).NotEmpty().WithMessage("El campo fehaServicio no puede ir vacio");
            RuleFor(s => s.Estado).NotEmpty().WithMessage("El campo estado no puede ir vacio");
        }
    }
}

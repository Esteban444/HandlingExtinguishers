using FluentValidation;
using ManagementFireEstinguisher.Dto.Services;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    class ValidacionServicios : AbstractValidator<ServicioBase>
    {
        public ValidacionServicios()
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

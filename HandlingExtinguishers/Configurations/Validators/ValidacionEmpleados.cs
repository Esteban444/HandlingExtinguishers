using FluentValidation;
using HandlingExtinguisher.Dto.Employees;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidacionEmpleados : AbstractValidator<EmployeeBase>
    {
        public ValidacionEmpleados()
        {
            RuleFor(empleado => empleado.IdCompany)
                .NotNull()
                .NotEmpty()
                .WithMessage("El campo idempresa no puede ir vacio, y la empresa debe existir en la tabla empresas de la base de datos");

            RuleFor(empleado => empleado.Nombre)
                .NotEmpty()
            .WithMessage("El campo nombre no puede ir vacio");

            RuleFor(empleado => empleado.Apellido)
                .NotEmpty()
            .WithMessage("El campo Apellido no puede ir vacio");

            RuleFor(empleado => empleado.Telefono)
                .NotEmpty()
            .WithMessage("El campo telefono no puede ir vacia");

            RuleFor(empleado => empleado.Email)
                .NotEmpty()
                .WithMessage("El campo email no puede ir vacio");
        }
    }
}

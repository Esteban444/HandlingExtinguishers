using FluentValidation;
using ManagementFireEstinguisher.Dto.Prices;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidacionesPrecios : AbstractValidator<PrecioBase>
    {
        public ValidacionesPrecios()
        {
            RuleFor(precio => precio.IdProductos).NotEmpty()
                .WithMessage("El campo id productos no puede ir vacio,El producto debe existir en la tabla productos de la base de datos");

            RuleFor(precio => precio.Descripcion)
                   .NotEmpty()
               .WithMessage("La descripcion no puede ir vacio");

            RuleFor(precio => precio.Valor)
                   .NotEmpty()
               .WithMessage("El Valor no puede ir vacio");
        }
    }
}

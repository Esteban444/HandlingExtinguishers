using FluentValidation;
using HandlingExtinguishers.Models.Prices;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidatorPrice : AbstractValidator<PrecioBase>
    {
        public ValidatorPrice()
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

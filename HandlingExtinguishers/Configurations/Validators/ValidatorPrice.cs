namespace HandlingExtinguishers.Configurations.Validators;

using FluentValidation;
using HandlingExtinguishers.Models.Prices;

public class ValidatorPrice : AbstractValidator<PriceRequest>
{
    public ValidatorPrice()
    {
        RuleFor(precio => precio.ProductId).NotEmpty()
            .WithMessage("El campo id productos no puede ir vacio,El producto debe existir en la tabla productos de la base de datos");

        RuleFor(precio => precio.Description)
               .NotEmpty()
           .WithMessage("La descripcion no puede ir vacio");

        RuleFor(precio => precio.Value)
               .NotEmpty()
           .WithMessage("El Valor no puede ir vacio");
    }
}

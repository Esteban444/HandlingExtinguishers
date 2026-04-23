namespace HandlingExtinguishers.Configurations.Validators;

using FluentValidation;
using HandlingExtinguishers.Models.Inventories;

public class ValidatorInventory : AbstractValidator<InventarioRequest>
{
    public ValidatorInventory()
    {
        RuleFor(i => i.ProductId).NotEmpty()
           .WithMessage("El campo idproductos no puede ir vacio, y el producto debe existir en la tabla Productos de la base de datos");

        RuleFor(i => i.Description)
            .NotEmpty()
        .WithMessage("El campo descripcion no puede ir vacio");

        RuleFor(i => i.Date)
            .NotEmpty()
        .WithMessage("El campo fecha no puede ir vacio");

        RuleFor(i => i.Quantity)
            .NotEmpty()
        .WithMessage("El campo cantidad no puede ir vacia");

        RuleFor(i => i.ExpirationDate)
            .NotEmpty()
        .WithMessage("El campo fechaVencimiento no puede ir vacia");
    }
}

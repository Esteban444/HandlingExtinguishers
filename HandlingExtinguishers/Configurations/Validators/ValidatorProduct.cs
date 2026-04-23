namespace HandlingExtinguishers.Configurations.Validators;

using FluentValidation;
using HandlingExtinguishers.Models.Products;

class ValidatorProduct : AbstractValidator<ProductRequest>
{
    public ValidatorProduct()
    {
        RuleFor(p => p.WeightExtinguisherId).NotEmpty()
            .WithMessage("El campo idPesoExtintor debe existir en la tabla PesoExtintores de la base de datos");

        RuleFor(p => p.TypeExtinguisherId).NotEmpty()
            .WithMessage("El campo idTipoExtintor debe existir en la tabla TipoExtintores de la base de datos");

        RuleFor(p => p.ProductType)
                .NotEmpty()
            .WithMessage("El campo tipo de producto no puede ir vacio");



    }
}

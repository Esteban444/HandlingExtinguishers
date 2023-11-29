using FluentValidation;
using ManagementFireEstinguisher.Dto.Products;


namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    class ValidacionesProducto : AbstractValidator<ProductoBase>
    {
        public ValidacionesProducto()
        {
            RuleFor(p => p.IdPesoExtintor).NotEmpty()
                .WithMessage("El campo idPesoExtintor debe existir en la tabla PesoExtintores de la base de datos");

            RuleFor(p => p.IdTipoExtintor).NotEmpty()
                .WithMessage("El campo idTipoExtintor debe existir en la tabla TipoExtintores de la base de datos");

            RuleFor(p => p.TipoProducto)
                    .NotEmpty()
                .WithMessage("El campo tipo de producto no puede ir vacio");



        }
    }
}

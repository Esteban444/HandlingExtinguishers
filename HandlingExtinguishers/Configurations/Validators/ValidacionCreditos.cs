using FluentValidation;
using ManagementFireEstinguisher.Dto.Credit;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidacionCreditos : AbstractValidator<CreditoServicioBase>
    {
        public ValidacionCreditos()
        {
            RuleFor(x => x.IdServicio).NotEmpty().WithMessage("El campo IdServicio deve ir con un dato valido.");
            RuleFor(x => x.Abono).NotEmpty().WithMessage("El campo Abono no puede ir vacío.");
            RuleFor(x => x.Deuda).NotEmpty().WithMessage("El campo Deuda no puede ir vacío.");
            RuleFor(x => x.Fecha).NotEmpty().WithMessage("El campo Fecha no puede ir vacío.");
        }
    }
}

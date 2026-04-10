using FluentValidation;
using ManagementFireEstinguisher.Dto.Extinguishers;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidatorTypeExtinguisher : AbstractValidator<TipoExtintorBase>
    {
        public ValidatorTypeExtinguisher()
        {
            RuleFor(t => t.Tipo_Extintor).NotEmpty().WithMessage("El campo tipoExtintor no puede ir vacio");
        }
    }
}

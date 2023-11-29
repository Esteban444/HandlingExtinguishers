using FluentValidation;
using ManagementFireEstinguisher.Dto.Extinguishers;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidacionTipoExtintor : AbstractValidator<TipoExtintorBase>
    {
        public ValidacionTipoExtintor()
        {
            RuleFor(t => t.Tipo_Extintor).NotEmpty().WithMessage("El campo tipoExtintor no puede ir vacio");
        }
    }
}

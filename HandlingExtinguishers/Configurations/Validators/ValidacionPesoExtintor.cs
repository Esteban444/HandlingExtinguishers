using FluentValidation;
using ManagementFireEstinguisher.Dto.Extinguishers;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidacionPesoExtintor : AbstractValidator<PesoExtintorBase>
    {
        public ValidacionPesoExtintor()
        {
            RuleFor(p => p.PesoXlibras).NotEmpty().WithMessage("El campo pesoXlibras no puede ir vacio");
        }
    }
}

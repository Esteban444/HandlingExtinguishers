using FluentValidation;
using HandlingExtinguishers.Models.Extinguishers;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidacionPesoExtintor : AbstractValidator<WeightExtinguisherBase>
    {
        public ValidacionPesoExtintor()
        {
            RuleFor(p => p.PesoXlibras).NotEmpty().WithMessage("El campo pesoXlibras no puede ir vacio");
        }
    }
}

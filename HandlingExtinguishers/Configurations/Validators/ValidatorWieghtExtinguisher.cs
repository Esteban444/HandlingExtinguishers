using FluentValidation;
using HandlingExtinguishers.Models.Extinguishers;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidatorWieghtExtinguisher : AbstractValidator<WeightExtinguisherBase>
    {
        public ValidatorWieghtExtinguisher()
        {
            RuleFor(p => p.PesoXlibras).NotEmpty().WithMessage("El campo pesoXlibras no puede ir vacio");
        }
    }
}

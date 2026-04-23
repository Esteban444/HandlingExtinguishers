using FluentValidation;
using HandlingExtinguishers.Models.Extinguishers;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidatorTypeExtinguisher : AbstractValidator<TypeExtinguisherRequest>
    {
        public ValidatorTypeExtinguisher()
        {
            RuleFor(t => t.TypeExtinguisher).NotEmpty().WithMessage("El campo tipoExtintor no puede ir vacio");
        }
    }
}

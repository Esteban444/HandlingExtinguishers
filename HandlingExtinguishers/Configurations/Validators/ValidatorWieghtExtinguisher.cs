namespace HandlingExtinguishers.Configurations.Validators;

using FluentValidation;
using HandlingExtinguishers.Models.Extinguishers;

public class ValidatorWieghtExtinguisher : AbstractValidator<WightExtinguisherRequest>
{
    public ValidatorWieghtExtinguisher()
    {
        RuleFor( weight => weight.WeightInPounds).NotEmpty().WithMessage("El campo WeightInPounds no puede ir vacio");
    }
}

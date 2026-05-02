namespace HandlingExtinguishers.Configurations.Validators;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Models.Services;
# endregion

class ValidatorService : AbstractValidator<ServiceRequest>
{
    public ValidatorService()
    {
        RuleFor( service => service.ClientId ).NotEmpty()
            .WithMessage( ValidatorMessageCommonConstants.CustomerCannotBeEmpty );

        RuleFor( service => service.EmployeeId ).NotEmpty()
            .WithMessage( ValidatorMessageCommonConstants.EmployeeCannotBeEmpty );

        RuleFor( service => service.ServiceDate ).NotEmpty().WithMessage( ValidatorMessageCommonConstants.DateServiceCannotBeEmpty );

        RuleFor( service => service.StateService ).NotEmpty().WithMessage( ValidatorMessageCommonConstants.StateCannotBeEmpty );
    }
}

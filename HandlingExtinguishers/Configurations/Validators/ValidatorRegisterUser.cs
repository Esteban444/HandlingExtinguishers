namespace HandlingExtinguishers.Configurations.Validators;

using FluentValidation;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Models.Authentication;

public class ValidatorRegisterUser : AbstractValidator<RegisterUserRequest>
{
    public ValidatorRegisterUser() 
    {
        RuleFor( field => field.Email).NotEmpty().WithMessage( ValidatorMessageCommonConstants.EmailCannotBeEmpty );
        RuleFor( field => field.Password).NotEmpty().WithMessage( ValidatorMessageCommonConstants.PasswordCannotBeEmpty );
        RuleFor( field => field.FullName).NotEmpty().WithMessage(ValidatorMessageCommonConstants.FullNameCannotBeEmpty );
        RuleFor( field => field.UserName).NotEmpty().WithMessage(ValidatorMessageCommonConstants.UserNameCannotBeEmpty );
    }
}

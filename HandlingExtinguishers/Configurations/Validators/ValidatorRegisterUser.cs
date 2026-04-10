namespace HandlingExtinguishers.Configurations.Validators;

using FluentValidation;
using HandlingExtinguishers.Core.Helpers;
using ManagementFireEstinguisher.Dto.Users;

public class ValidatorRegisterUser : AbstractValidator<RegisterUserDto>
{
    public ValidatorRegisterUser() 
    {
        RuleFor( field => field.Email).NotEmpty().WithMessage( ValidatorMessageCommonConstants.EmailCannotBeEmpty );
        RuleFor( field => field.Password).NotEmpty().WithMessage( ValidatorMessageCommonConstants.PasswordCannotBeEmpty );
        RuleFor( field => field.FullName).NotEmpty().WithMessage(ValidatorMessageCommonConstants.FullNameCannotBeEmpty );
        RuleFor( field => field.UserName).NotEmpty().WithMessage(ValidatorMessageCommonConstants.UserNameCannotBeEmpty );
    }
}

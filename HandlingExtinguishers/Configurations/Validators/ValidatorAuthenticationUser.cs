using FluentValidation;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Models.Authentication;

namespace HandlingExtinguishers.Configurations.Validators
{
    public class ValidatorAuthenticationUser : AbstractValidator<LoginRequest>
    {
        public ValidatorAuthenticationUser()
        {
            RuleFor( field => field.Email).NotEmpty().WithMessage( ValidatorMessageCommonConstants.EmailCannotBeEmpty );

            RuleFor( field => field.Password).NotEmpty().WithMessage( ValidatorMessageCommonConstants.PasswordCannotBeEmpty );
        }
    }
}

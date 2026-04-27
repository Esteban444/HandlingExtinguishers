namespace HandlingExtinguishers.Configurations.Validators;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Models.Company;
#endregion

public class ValidatorCompany : AbstractValidator<CompanyRequest>
{
    public ValidatorCompany()
    {
        RuleFor(x => x.Name).NotEmpty().
                    WithMessage( ValidatorMessageCommonConstants.NameCannotBeEmpty );

        RuleFor(x => x.Address).NotEmpty().
              WithMessage( ValidatorMessageCommonConstants.AddressCannotBeEmpty );

        RuleFor(x => x.Email).NotEmpty().
             WithMessage( ValidatorMessageCommonConstants.EmailCannotBeEmpty );
    }
}

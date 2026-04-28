namespace HandlingExtinguishers.Configurations.Validators;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Models.Employees;
#endregion

public class ValidatorEmployee : AbstractValidator<EmployeeRequest>
{
    public ValidatorEmployee()
    {
        RuleFor( employee => employee.CompanyId )
            .NotEmpty()
            .WithMessage( ValidatorMessageCommonConstants.CompanyIdCannotBeEmpty );

        RuleFor( employee => employee.FirstName)
            .NotEmpty()
        .WithMessage(ValidatorMessageCommonConstants.FirstNameCannotBeEmpty);

        RuleFor( employee => employee.LastName)
            .NotEmpty()
        .WithMessage( ValidatorMessageCommonConstants.LastNameCannotBeEmpty );

        RuleFor( employee => employee.Phone )
            .NotEmpty()
        .WithMessage( ValidatorMessageCommonConstants.PhoneCannotBeEmpty );

        RuleFor( employee => employee.Email )
            .NotEmpty()
            .WithMessage( ValidatorMessageCommonConstants.EmailCannotBeEmpty );
    }
}

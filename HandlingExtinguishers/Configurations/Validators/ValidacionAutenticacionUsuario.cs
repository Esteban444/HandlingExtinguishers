using FluentValidation;
using HandlingExtinguisher.Dto.Users;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidacionAutenticacionUsuario : AbstractValidator<LoginRequestDto>
    {
        public ValidacionAutenticacionUsuario()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("El campo Email no puede ir vacío");
            RuleFor(x => x.Password).NotEmpty().WithMessage("El campo Password no puede ir vacío");
        }
    }
}

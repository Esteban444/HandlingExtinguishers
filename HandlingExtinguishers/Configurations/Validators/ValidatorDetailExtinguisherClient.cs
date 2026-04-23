namespace HandlingExtinguishers.Configurations.Validators;

using FluentValidation;
using HandlingExtinguishers.Models.Clients;

public class ValidatorDetailExtinguisherClient : AbstractValidator<DetailExtinguisherClientRequest>
{
    public ValidatorDetailExtinguisherClient()
    {
        RuleFor(x => x.IdClients).NotEmpty().WithMessage("El campo cliente debe existir en la tabla clientes de la base de datos.");
        RuleFor(x => x.TypeExtinguisher).NotEmpty().WithMessage("El campo tipo extintor no puede ir vacío.");
        RuleFor(x => x.MaintenanceDate).NotEmpty().WithMessage("El campo fecha mantenimiento no puede ir vacío.");
        RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage("El campo fecha Vencimiento no puede ir vacío.");
    }
}

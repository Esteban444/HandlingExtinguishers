using FluentValidation;
using HandlingExtinguisher.Dto.Clients;

namespace HandlingExtinguishers.WebApi.Configurations.Validators
{
    public class ValidacionDetalleExtintorClientes : AbstractValidator<BaseDetailExtinguisherClient>
    {
        public ValidacionDetalleExtintorClientes()
        {
            RuleFor(x => x.IdClients).NotEmpty().WithMessage("El campo cliente debe existir en la tabla clientes de la base de datos.");
            RuleFor(x => x.TypeExtinguisher).NotEmpty().WithMessage("El campo tipo extintor no puede ir vacío.");
            RuleFor(x => x.MaintenanceDate).NotEmpty().WithMessage("El campo fecha mantenimiento no puede ir vacío.");
            RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage("El campo fecha Vencimiento no puede ir vacío.");
        }
    }
}

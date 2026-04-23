using HandlingExtinguishers.Models.Extinguishers;

namespace HandlingExtinguishers.Contracts.Interfaces.Services;


public interface ITypeExtinguisherService
{
    Task<IEnumerable<TypeExtinguisherRequest>> ConsultaTipoExtintor();
    Task<TypeExtinguisherRequest> ConsultaTipoId(Guid id);
    Task<TypeExtinguisherRequest> CrearTipoExtintor(TypeExtinguisherRequest tipo);
    Task<TypeExtinguisherRequest> ActualizarTipoExtintor(Guid id, TypeExtinguisherRequest tipo);
    Task<TypeExtinguisherRequest> EliminarTipoExtintor(Guid id);
}

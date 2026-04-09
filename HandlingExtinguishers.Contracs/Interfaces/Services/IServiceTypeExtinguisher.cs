using ManagementFireEstinguisher.Dto.Extinguishers;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceTypeExtinguisher
    {
        Task<IEnumerable<TipoExtintorDTO>> ConsultaTipoExtintor();
        Task<TipoExtintorDTO> ConsultaTipoId(Guid id);
        Task<TipoExtintorBase> CrearTipoExtintor(TipoExtintorBase tipo);
        Task<TipoExtintorBase> ActualizarTipoExtintor(Guid id, TipoExtintorBase tipo);
        Task<TipoExtintorDTO> EliminarTipoExtintor(Guid id);
    }
}

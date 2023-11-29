using ManagementFireEstinguisher.Dto.Extinguishers;

namespace HandlingFireExtinguisher.Contracts.Interfaces.Services
{
    public interface IServicioTipoExtintor
    {
        Task<IEnumerable<TipoExtintorDTO>> ConsultaTipoExtintor();
        Task<TipoExtintorDTO> ConsultaTipoId(Guid id);
        Task<TipoExtintorBase> CrearTipoExtintor(TipoExtintorBase tipo);
        Task<TipoExtintorBase> ActualizarTipoExtintor(Guid id, TipoExtintorBase tipo);
        Task<TipoExtintorDTO> EliminarTipoExtintor(Guid id);
    }
}

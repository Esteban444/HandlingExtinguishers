using ManagementFireEstinguisher.Dto.Extinguishers;

namespace HandlingFireExtinguisher.Contracts.Interfaces.Services
{
    public interface IServicioPesoExtintor
    {
        Task<IEnumerable<PesoExtintorDTO>> ConsultaPesoExtintor();
        Task<PesoExtintorDTO> ConsultaPorId(Guid id);
        Task<PesoExtintorBase> CrearPesoExtintor(PesoExtintorBase peso);
        Task<PesoExtintorBase> ActualizarPesoExtintor(Guid id, PesoExtintorBase peso);
        Task<PesoExtintorDTO> EliminarPesoExtintor(Guid id);
    }
}

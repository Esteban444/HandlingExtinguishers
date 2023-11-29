using ManagementFireEstinguisher.Dto.Expenses;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingFireExtinguisher.Contracts.Interfaces.Services
{
    public interface IServicioGasto
    {
        Task<IEnumerable<GastosDTO>> GetGastos(FiltrosGastos filtros);
        Task<GastosDTO> GetGasto(Guid id);
        Task<GastosBase> CrearGasto(GastosBase gasto);
        Task<GastosBase> ActualizarGasto(Guid id, GastosBase gasto);
        Task<GastosDTO> EliminarGasto(Guid id);

    }
}
using CPP.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Interfaces
{
    public interface IReportesRepository
    {
        Task<ReporteVencidoDto[]> GetRemisionesVencidas(int proveedorId, int sucursalId);

        Task<ReporteVencidoDto[]> GetRemisionesPorVencer(int proveedorId, int sucursalId);

        Task<PagoProveedoresDto[]> GetPagoOrdenesPorProveedor(int proveedorId);

        Task<PagoRemisionDto[]> GetPagoRemisiones(int proveedorId, int sucursalId);
    }
}

using CPP.Entities.Data;
using CPP.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Interfaces
{
    public interface IOrdenesRepository
    {
        Task<RemisionesOrdenesDto[]> ObtenerRemisionesOrdenes(int proveedorId);

        Task<bool> AltaOrdenes(OrdenAltaDto orden);

        Task<Ordenes> ObtenerOrdenById(int ordenId);

        Task<bool> ActualizarOrdenes(OrdenUpdateDto ordenDto);

        Task<OrdenesCreadasDto[]> ObtenerOrdenesCreadas();


    }
}

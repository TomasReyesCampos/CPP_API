using CPP.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Interfaces
{
    public interface ITipoProveedorRepository
    { 
        Task<TipoProveedor[]> GetTipoProveedor();
        Task<TipoProveedor> GetTipoProveedorPorId(int id);
        Task<TipoProveedor> GetTipoProveedorNombre(string nombre);
        Task<TipoProveedor[]> GetProveedoresPorTipoProveedor(int id);
    }
}

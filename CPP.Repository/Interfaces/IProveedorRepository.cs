using CPP.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Interfaces
{
   public interface IProveedorRepository
    {
        Task<Proveedor[]> GetProveedor();
        Task<Proveedor> GetProveedorPorId(int id);
        Task<Proveedor> GetProveedorNombre(string nombre);
        Task<Proveedor[]> GetOrdenesPorProveedor(int id);
    }
}

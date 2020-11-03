using CPP.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Interfaces
{
    public interface ISucursalRepository
    {
        Task<Sucursal[]> GetSucursal();
        Task<Sucursal> GetSucursalPorId(int id);
        Task<Sucursal> GetSucursalNombre(string nombre);
    }
}

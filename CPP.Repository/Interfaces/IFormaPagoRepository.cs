using CPP.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Interfaces
{
    public interface IFormaPagoRepository
    { 
        Task<FormaPago[]> GetFormaPago();
        Task<FormaPago> GetFormaPagoPorId(int id);
        Task<FormaPago> GetFormaPagoPorNombre(string nombre);
    }
}

using CPP.Entities.Data;
using CPP.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Interfaces
{
    public interface IRemisionesRepository
    {
        Task<RemisionDto[]> GetRemisiones();
        Task<RemisionDto> GetRemisionPorId(int id);
        Task<Remision> GetRemisionNoDtoPorId(int id);
    }
}

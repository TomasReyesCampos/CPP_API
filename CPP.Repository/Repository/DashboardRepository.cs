using CPP.Entities.Dtos;
using CPP.Repository.Context;
using CPP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Repository
{
    public class DashboardRepository : BaseRepository, IDashboardRepository
    {

        private readonly CPPContext _context;
        public DashboardRepository(CPPContext context) :
             base(context)
        {
            this._context = context;
        }

        public async Task<DashboardDto[]> GetDashboardData()
        {
            IQueryable<DashboardDto> query = (from r in _context.remision
                                             join er in _context.estado_remision on r.estado_remision_id equals er.Id
                                             join suc in _context.sucursal on r.sucursal_id equals suc.Id
                                             join prov in _context.proveedor on r.proveedor_id equals prov.Id
                                             join fp in _context.forma_pago on prov.forma_pago_id equals fp.Id                                                                                  
                                              select new DashboardDto()
                                              {
                                                  estado = er.estado_remision,
                                                  remision_id = r.Id,
                                                  sucursal = suc.nombre,
                                                  proveedor = prov.nombre,
                                                  fecha_alta = r.fecha_remision,
                                                  fecha_credito = r.fecha_pago.AddDays(prov.dias_credito),
                                                  forma_pago = fp.forma_pago,
                                                  estado_id = er.Id,
                                                  fecha_real_pago = r.fecha_real_pago
                                              });

            return await query.ToArrayAsync();
        }
    }
}

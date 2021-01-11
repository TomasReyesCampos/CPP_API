using CPP.Entities.Data;
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
    public class RemisionRepository : BaseRepository, IRemisionesRepository
    {

        private readonly CPPContext _context;
        public RemisionRepository(CPPContext context) :
             base(context)
        {
            this._context = context;
        }

        public async Task<RemisionDto[]> GetRemisiones()
        {
            IQueryable<RemisionDto> query = (from r in _context.remision
                                             join er in _context.estado_remision on r.estado_remision_id equals er.Id
                                             join suc in _context.sucursal on r.sucursal_id equals suc.Id
                                             join prov in _context.proveedor on r.proveedor_id equals prov.Id
                                            select new RemisionDto()
                                            {
                                                activo = r.activo,
                                                cantidad = r.cantidad,
                                                comentarios = r.comentarios,
                                                estado_remision = er.estado_remision,
                                                estado_remision_id = er.Id,
                                                fecha_pago = r.fecha_pago,
                                                fecha_remision = r.fecha_remision,
                                                Id = r.Id,
                                                proveedor_id = r.proveedor_id,
                                                sucursal = suc.nombre,
                                                sucursal_id = suc.Id,
                                                proveedor = prov.nombre,
                                                numero_remision = r.numero_remision
                                            });

            return await query.ToArrayAsync();
        } 
        public async Task<RemisionDto> GetRemisionPorId(int id)
        {
            IQueryable<RemisionDto> query = (from r in _context.remision
                                             join er in _context.estado_remision on r.estado_remision_id equals er.Id
                                             join suc in _context.sucursal on r.sucursal_id equals suc.Id
                                             join prov in _context.proveedor on r.proveedor_id equals prov.Id
                                             where r.Id == id
                                             select new RemisionDto()
                                             {
                                                 activo = r.activo,
                                                 cantidad = r.cantidad,
                                                 comentarios = r.comentarios,
                                                 estado_remision = er.estado_remision,
                                                 estado_remision_id = er.Id,
                                                 fecha_pago = r.fecha_pago,
                                                 fecha_remision = r.fecha_remision,
                                                 Id = r.Id,
                                                 proveedor_id = r.proveedor_id,
                                                 sucursal = suc.nombre,
                                                 sucursal_id = suc.Id,
                                                 proveedor = prov.nombre,
                                                 numero_remision = r.numero_remision
                                             });

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Remision> GetRemisionNoDtoPorId(int id)
        {
            IQueryable<Remision> query = from r in _context.remision
                                         where r.Id == id
                                         select r;

            return await query.FirstOrDefaultAsync();
        }
    }
}

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
    public class OrdenesRespository : BaseRepository, IOrdenesRepository
    {
        private readonly CPPContext _context;
        public OrdenesRespository(CPPContext context) :
             base(context)
        {
            this._context = context;
        }

        public async Task<bool> AltaOrdenes(OrdenAltaDto ordenDto)
        {
            var orden = new Ordenes();
            orden.estado_orden_id = 1;
            orden.fecha_alta = DateTime.Now;
            orden.proveedor_id = ordenDto.proveedor_id;
            orden.remisiones = new List<Remision>();

            for (int i = 0; i <= ordenDto.remisiones.Length - 1; i++)
            {
                var remision_id = ordenDto.remisiones[i];
                var remision = await _context.remision.Where(r => r.Id == remision_id).FirstOrDefaultAsync();

                if (remision != null) {
                    remision.estado_remision_id = 2;
                    orden.remisiones.Add(remision); 
                }
            }

            _context.orden.Add(orden);

          return await SaveChangesAsync();
        }

        public async Task<bool> ActualizarOrdenes(OrdenUpdateDto ordenDto)
        {
            var orden = await ObtenerOrdenById(ordenDto.orden_id);

            foreach (var remisiones in orden.remisiones)
            {
                remisiones.estado_remision_id = 1;
            }

            for (int i = 0; i <= ordenDto.remisiones.Length - 1; i++)
            {
                var remision_id = ordenDto.remisiones[i];
                var remision = await _context.remision.Where(r => r.Id == remision_id).FirstOrDefaultAsync();

                if (remision != null)
                {
                    remision.estado_remision_id = 2;
                    orden.remisiones.Add(remision);
                }
            }             

            return await SaveChangesAsync();
        }

        public async Task<Ordenes> ObtenerOrdenById(int ordenId)
        {
            IQueryable<Ordenes> query = (from o in _context.orden
                                         where o.Id == ordenId
                                         select o).Include(r => r.remisiones);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<RemisionesOrdenesDto[]> ObtenerRemisionesOrdenes(int proveedorId)
        {
            IQueryable<RemisionesOrdenesDto> query = (from r in _context.remision
                                                      join er in _context.estado_remision on r.estado_remision_id equals er.Id
                                                      join suc in _context.sucursal on r.sucursal_id equals suc.Id
                                                      join prov in _context.proveedor on r.proveedor_id equals prov.Id
                                                      join fp in _context.forma_pago on prov.forma_pago_id equals fp.Id
                                                      where r.proveedor_id == proveedorId
                                                        && r.estado_remision_id == 1
                                                      //  && r.activo == true
                                                      select new RemisionesOrdenesDto()
                                                      {
                                                          fecha_pago = r.fecha_pago,
                                                          fecha_remision = r.fecha_remision,
                                                          Id = r.Id,
                                                          sucursal = suc.nombre,
                                                          monto = r.cantidad,
                                                          forma_pago = fp.forma_pago,
                                                          usuario = "Prueba"

                                                      }).OrderBy(p => p.fecha_remision);

            return await query.ToArrayAsync();
        }

        public async Task<OrdenesCreadasDto[]> ObtenerOrdenesCreadas()
        {

            IQueryable<OrdenesCreadasDto> query = (from ord in _context.orden
                                                   join prov in _context.proveedor on ord.proveedor_id equals prov.Id
                                                   join fp in _context.forma_pago on prov.forma_pago_id equals fp.Id                                                  
                                                   join eord in _context.estado_orden on ord.estado_orden_id equals eord.Id
                                                   select new OrdenesCreadasDto()
                                                   {
                                                          fecha_pago = ord.fecha_alta.AddDays(prov.dias_credito),
                                                          fecha_alta = ord.fecha_alta,
                                                          usuario_alta = "Prueba",
                                                          orden_id = ord.Id,
                                                          estatus = eord.estado_orden,
                                                          estado_orden_id = eord.Id,
                                                          proveedor = prov.nombre,
                                                          monto_total = ord.remisiones.Select( s=> s.cantidad).Sum(),
                                                          total_remisiones = ord.remisiones.Count,
                                                          forma_pago = fp.forma_pago,
                                                          forma_pago_id = fp.Id
                                                   }); 

            return await query.ToArrayAsync();
        }
    }
}

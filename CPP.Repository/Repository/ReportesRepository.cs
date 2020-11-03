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
    public class ReportesRepository : BaseRepository, IReportesRepository
    {
        private readonly CPPContext _context;
        public ReportesRepository(CPPContext context) :
             base(context)
        {
            this._context = context;
        }

        public async Task<ReporteVencidoDto[]> GetRemisionesVencidas(int proveedorId, int sucursalId)
        {
            DateTime timeNow = DateTime.Now;
            IQueryable<ReporteVencidoDto> query = (from r in _context.remision
                                              join er in _context.estado_remision on r.estado_remision_id equals er.Id
                                              join suc in _context.sucursal on r.sucursal_id equals suc.Id
                                              join prov in _context.proveedor on r.proveedor_id equals prov.Id
                                              join fp in _context.forma_pago on prov.forma_pago_id equals fp.Id
                                              where r.estado_remision_id == 1 
                                                   && r.fecha_pago < DateTime.Now
                                                   && (r.proveedor_id == proveedorId || proveedorId == 0)
                                                   && (r.sucursal_id == sucursalId || sucursalId == 0)
                                              select new ReporteVencidoDto()
                                              {
                                                  remision_id = r.Id,
                                                  sucursal = suc.nombre,
                                                  proveedor = prov.nombre,
                                                  fecha_alta = r.fecha_remision,
                                                  fecha_credito = r.fecha_pago,
                                                  forma_pago = fp.forma_pago,
                                                  dias_vencimiento = timeNow.Subtract( r.fecha_pago ).Days,
                                                  sucursal_id = suc.Id,
                                                  proveedor_id = prov.Id
                                              });          

            return await query.ToArrayAsync();
        }

        public async Task<ReporteVencidoDto[]> GetRemisionesPorVencer(int proveedorId, int sucursalId)
        {
            DateTime timeNow = DateTime.Now;
            IQueryable<ReporteVencidoDto> query = (from r in _context.remision
                                                   join er in _context.estado_remision on r.estado_remision_id equals er.Id
                                                   join suc in _context.sucursal on r.sucursal_id equals suc.Id
                                                   join prov in _context.proveedor on r.proveedor_id equals prov.Id
                                                   join fp in _context.forma_pago on prov.forma_pago_id equals fp.Id
                                                   where r.estado_remision_id == 1
                                                        && r.fecha_pago > DateTime.Now
                                                      //  && timeNow.Subtract(r.fecha_pago).Days >= 5
                                                        && (r.proveedor_id == proveedorId || proveedorId == 0)
                                                        && (r.sucursal_id == sucursalId || sucursalId == 0)
                                                   select new ReporteVencidoDto()
                                                   {
                                                       remision_id = r.Id,
                                                       sucursal = suc.nombre,
                                                       proveedor = prov.nombre,
                                                       fecha_alta = r.fecha_remision,
                                                       fecha_credito = r.fecha_pago,
                                                       forma_pago = fp.forma_pago,
                                                       dias_vencimiento = timeNow.Subtract(r.fecha_pago).Days,
                                                       sucursal_id = suc.Id,
                                                       proveedor_id = prov.Id
                                                   });

            return await query.ToArrayAsync();
        }
 

        public async Task<PagoProveedoresDto[]> GetPagoOrdenesPorProveedor(int proveedorId)
        {
            DateTime timeNow = DateTime.Now;
            IQueryable<PagoProveedoresDto> query = (from ord in _context.orden
                                                   join prov in _context.proveedor on ord.proveedor_id equals prov.Id
                                                   join fp in _context.forma_pago on prov.forma_pago_id equals fp.Id
                                                   where (ord.proveedor_id == proveedorId || proveedorId == 0)
                                                   select new PagoProveedoresDto()
                                                   {
                                                       orden_id = ord.Id,
                                                       proveedor = prov.nombre,
                                                       fecha_alta = ord.fecha_alta,
                                                        banco = ord.banco,
                                                        fecha_pago = ord.fecha_pago,
                                                        numero_cheque = ord.numero_cheque,
                                                        numero_remisiones = ord.remisiones.Count,
                                                        numero_transferencia = ord.numero_transferencia,
                                                        persona_recibe = ord.persona_recibe,
                                                        usuario_alta = "Prueba",
                                                        forma_pago = fp.forma_pago

                                                   });

            return await query.ToArrayAsync();
        }
    }
}

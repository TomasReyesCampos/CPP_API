using CPP.Entities.Data;
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
    public class ProveedorRepository : BaseRepository, IProveedorRepository
    {
        private readonly CPPContext _context;
        public ProveedorRepository(CPPContext context) :
             base(context)
        {
            this._context = context;
        }

        public async Task<Proveedor[]> GetOrdenesPorProveedor(int id)
        {
            IQueryable<Proveedor> query = (from s in _context.proveedor
                                           join fp in _context.remision on s.Id equals fp.proveedor_id
                                           where s.Id == id
                                           select new Proveedor()
                                           {
                                               Id = s.Id,
                                               activo = s.activo,                                              
                                               codigo_postal = s.codigo_postal,
                                               dias_credito = s.dias_credito,
                                               direccion = s.direccion,
                                               forma_pago_id = s.forma_pago_id,
                                               tipo_proveedor_id = s.tipo_proveedor_id,
                                               nombre = s.nombre,
                                               rfc = s.rfc,
                                               telefono = s.telefono,
                                               correo = s.correo
                                           }).AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Proveedor[]> GetProveedor()
        {
            IQueryable<Proveedor> query = (from s in _context.proveedor
                                           join fp in _context.forma_pago on s.forma_pago_id equals fp.Id
                                           join tp in _context.tipo_proveedor on s.tipo_proveedor_id equals tp.Id
                                           select new Proveedor()
                                           {
                                               Id = s.Id,
                                               activo = s.activo,
                                               tipo_proveedor_descripcion = tp.tipo_proveedor,
                                               forma_pago_descripcion = fp.forma_pago,
                                               codigo_postal = s.codigo_postal,
                                               dias_credito = s.dias_credito,
                                               direccion = s.direccion,
                                               forma_pago_id = s.forma_pago_id,
                                               tipo_proveedor_id = s.tipo_proveedor_id,
                                               nombre = s.nombre,
                                               rfc = s.rfc,
                                               telefono = s.telefono,
                                               correo = s.correo
                                           }).AsNoTracking();                                        
                                             
            return await query.ToArrayAsync();
        }

        public async Task<Proveedor> GetProveedorNombre(string nombre)
        {
            IQueryable<Proveedor> query = (from s in _context.proveedor
                                           join fp in _context.forma_pago on s.forma_pago_id equals fp.Id
                                           join tp in _context.tipo_proveedor on s.tipo_proveedor_id equals tp.Id
                                           where s.nombre == nombre
                                           select new Proveedor()
                                           {
                                               Id = s.Id,
                                               activo = s.activo,
                                               tipo_proveedor_descripcion = tp.tipo_proveedor,
                                               forma_pago_descripcion = fp.forma_pago,
                                               codigo_postal = s.codigo_postal,
                                               dias_credito = s.dias_credito,
                                               direccion = s.direccion,
                                               forma_pago_id = s.forma_pago_id,
                                               tipo_proveedor_id = s.tipo_proveedor_id,
                                               nombre = s.nombre,
                                               rfc = s.rfc,
                                               telefono = s.telefono
                                           });

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Proveedor> GetProveedorPorId(int id)
        {
            IQueryable<Proveedor> query = (from s in _context.proveedor
                                           join fp in _context.forma_pago on s.forma_pago_id equals fp.Id
                                           join tp in _context.tipo_proveedor on s.tipo_proveedor_id equals tp.Id
                                           where s.Id == id
                                           select new Proveedor()
                                           {
                                               Id = s.Id,
                                               activo = s.activo,
                                               tipo_proveedor_descripcion = tp.tipo_proveedor,
                                               forma_pago_descripcion = fp.forma_pago,
                                               codigo_postal = s.codigo_postal,
                                               dias_credito = s.dias_credito,
                                               direccion = s.direccion,
                                               forma_pago_id = s.forma_pago_id,
                                               tipo_proveedor_id = s.tipo_proveedor_id,
                                               nombre = s.nombre,
                                               rfc = s.rfc,
                                               telefono = s.telefono,
                                               correo = s.correo
                                           });

            return await query.FirstOrDefaultAsync();
        }
    }
}

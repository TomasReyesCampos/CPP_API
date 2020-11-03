using CPP.Entities.Data;
using CPP.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CPP.Entities.Dtos;
using CPP.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CPP.Repository.Repository
{
    public class TipoProveedorRepository : BaseRepository, ITipoProveedorRepository
    {
        private readonly CPPContext _context;
        public TipoProveedorRepository(CPPContext context) :
             base(context)
        {
            this._context = context;
        }

        public async Task<TipoProveedor[]> GetTipoProveedor()
        {
            IQueryable<TipoProveedor> query = (from s in _context.tipo_proveedor
                                           select s);

            return await query.ToArrayAsync();
        }

        public async Task<TipoProveedor> GetTipoProveedorNombre(string nombre)
        {
            IQueryable<TipoProveedor> query = (from s in _context.tipo_proveedor
                                           where s.tipo_proveedor == nombre
                                           select s);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TipoProveedor> GetTipoProveedorPorId(int id)
        {
            IQueryable<TipoProveedor> query = (from s in _context.tipo_proveedor
                                               where s.Id == id
                                               select s);

            return await query.FirstOrDefaultAsync();
        }

    }
}

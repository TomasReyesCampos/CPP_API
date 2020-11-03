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
    public class SucursalRepository : BaseRepository, ISucursalRepository
    {
        private readonly CPPContext _context;
        public SucursalRepository(CPPContext context) :
             base(context)
        {
            this._context = context;
        }

        public async Task<Sucursal[]> GetSucursal()
        {
            IQueryable<Sucursal> query = (from s in _context.sucursal
                                               select s);

            return await query.ToArrayAsync();
        }

        public async Task<Sucursal> GetSucursalNombre(string nombre)
        {
            IQueryable<Sucursal> query = (from s in _context.sucursal
                                               where s.nombre == nombre
                                               select s);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Sucursal> GetSucursalPorId(int id)
        {
            IQueryable<Sucursal> query = (from s in _context.sucursal
                                          where s.Id == id
                                          select s);

            return await query.FirstOrDefaultAsync();
        }
    }
}

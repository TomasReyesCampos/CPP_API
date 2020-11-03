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
    public class FormaPagoRepository : BaseRepository, IFormaPagoRepository
    {
        private readonly CPPContext _context;
        public FormaPagoRepository(CPPContext context) :
             base(context)
        {
            this._context = context;
        }

        public async Task<FormaPago[]> GetFormaPago()
        {
            IQueryable<FormaPago> query = (from s in _context.forma_pago
                                           select s);

            return await query.ToArrayAsync();
        }

        public async  Task<FormaPago> GetFormaPagoPorId(int id)
        {

            IQueryable<FormaPago> query = (from s in _context.forma_pago
                                           where s.Id == id
                                           select s);

            return await query.FirstOrDefaultAsync();
        }

        public async  Task<FormaPago> GetFormaPagoPorNombre(string nombre)
        {
            IQueryable<FormaPago> query = (from s in _context.forma_pago
                                           where s.forma_pago == nombre
                                           select s);

            return await query.FirstOrDefaultAsync();
        }
    }
}

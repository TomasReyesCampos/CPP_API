using CPP.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly CPPContext _context;
        public BaseRepository(CPPContext context)
        {
            this._context = context;
        }
        public virtual void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}

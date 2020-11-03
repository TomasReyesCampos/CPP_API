using CPP.Factory.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Factory.Repository
{
    public class FormaPagoRepository : CoreRepository<forma_pago, CPPEntity>
    {
        public FormaPagoRepository(CPPEntity context) : base(context)
        {
        
        }
    }
}

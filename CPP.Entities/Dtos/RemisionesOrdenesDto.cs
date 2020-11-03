using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public  class RemisionesOrdenesDto
    {
        public int Id { get; set; }

        public string sucursal { get; set; }

        public string usuario { get; set; }

        public DateTime fecha_remision { get; set; }

        public DateTime fecha_pago { get; set; }

        public float monto { get; set; }

        public string forma_pago { get; set; }
    }
}

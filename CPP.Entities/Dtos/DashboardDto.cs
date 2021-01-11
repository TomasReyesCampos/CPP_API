using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class DashboardDto
    {
        public int remision_id { get; set; }

        public int estado_id { get; set; }
        public string sucursal { get; set; }

        public string proveedor { get; set; }

        public string forma_pago { get; set; }

        public float monto { get; set; }

        public DateTime fecha_alta { get; set; }

        public DateTime fecha_credito { get; set; }

        public DateTime fecha_real_pago { get; set; }

        public string estado { get; set; }

    }
}

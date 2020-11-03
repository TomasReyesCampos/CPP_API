using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class OrdenesCreadasDto
    {
        public int orden_id { get; set; }

        public int estado_orden_id { get; set; }
        public int forma_pago_id { get; set; }

        public string proveedor { get; set; }
        public string forma_pago { get; set; }

        public string usuario_alta { get; set; }

        public DateTime fecha_alta { get; set; }

        public DateTime fecha_pago { get; set; }

        public string estatus { get; set; }

        public float monto_total { get; set; }

        public int  total_remisiones { get; set; }

    }
}

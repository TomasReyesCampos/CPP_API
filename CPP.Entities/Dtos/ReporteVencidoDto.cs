using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public  class ReporteVencidoDto
    {
        public int remision_id { get; set; }

        public int proveedor_id { get; set; }

        public int sucursal_id { get; set; }
        public string sucursal { get; set; }
        public string proveedor { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime fecha_credito { get; set; }
        public string forma_pago { get; set; }
        public int dias_vencimiento { get; set; }

    }
}

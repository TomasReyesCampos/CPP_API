using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class RemisionDto
    {
        public int Id { get; set; }
        public int proveedor_id { get; set; }
        public int estado_remision_id { get; set; }
        public string estado_remision { get; set; }

        public int sucursal_id { get; set; }

        public string sucursal  { get; set; }

        public string proveedor { get; set; }

        public float cantidad { get; set; }

        public DateTime fecha_remision { get; set; }

        public DateTime fecha_pago { get; set; }
        
        public DateTime fecha_alta { get; set; }

        public string comentarios { get; set; }

        public bool activo { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class RemisionAltaDto
    {
        public int Id { get; set; }
        public int proveedor_id { get; set; }
        
        public int sucursal_id { get; set; }

        public float cantidad { get; set; }

        public DateTime fecha_remision { get; set; }  

        public string comentarios { get; set; }
 
    }
}

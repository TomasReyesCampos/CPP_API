using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class OrdenAltaDto
    {
        public int proveedor_id { get; set; }
        public int[] remisiones { get; set; }
               
    }

    public class OrdenUpdateDto
    {
        public int orden_id { get; set; }
        public int proveedor_id { get; set; }
        public int[] remisiones { get; set; }
    }
}

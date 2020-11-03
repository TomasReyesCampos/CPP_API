using CPP.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class ProveedorDto : BaseDto, IEntity    {

        public int Id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string rfc { get; set; }
        public string codigo_postal { get; set; }
        public string telefono { get; set; }
        public int dias_credito { get; set; }
        public bool activo { get; set; }
        public int forma_pago_id { get; set; }
        public int tipo_proveedor_id { get; set; } 
    }
}

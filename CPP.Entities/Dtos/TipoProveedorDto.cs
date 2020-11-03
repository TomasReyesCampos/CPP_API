using CPP.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
   public class TipoProveedorDto :  BaseDto, IEntity
    {
        public int Id { get; set; } 
        public string tipo_proveedor { get; set; }
        public bool activo { get; set; }
        public string error { get; set; }

    }
}

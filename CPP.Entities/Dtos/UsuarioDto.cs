using CPP.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class UsuarioDto : BaseDto, IEntity
    {
        public int Id { get; set; }
        public int rol_id { get; set; }
        public string rol { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        public string nombre { get; set; }
        public int sucursal_id { get; set; }
        public string nombre_sucursal { get; set; }

        public bool activo { get; set; }
    }
}

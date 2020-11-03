using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("tipo_contacto")]
    public class TipoContacto : IEntity
    {
        public int Id { get ; set  ; }

        [Required]
        [StringLength(50)]
        public string tipo_contacto { get; set; }
        
        public bool activo { get; set; }

        public ProveedorContacto proveedor_contacto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("proveedor_contacto")]
    public class ProveedorContacto : IEntity
    {
        [Key]
        [Column("proveedor_contacto_id")]
        public int Id { get ; set; }  

        [ForeignKey("tipo_contacto")]
        public int tipo_contacto_id { get; set; }

        [Required]
        public string nombre { get; set; }
 
        public string correo { get; set; }
 
        public string telefono { get; set; }

        public string activo { get; set; }
       [Column("proveedor_id")]
        public virtual Proveedor Proveedor { get; set; }
        public virtual TipoContacto TipoContacto { get; set; }

  
    }
}

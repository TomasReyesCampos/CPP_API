using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    public class TipoProveedor : IEntity
    {

        [Column("tipo_proveedor_id")]
        public int Id { get; set; }
         
        [Required]
        [StringLength(50)]
        public string tipo_proveedor { get; set; }

        public bool activo { get; set; }
        public virtual Proveedor proveedor { get; set; }
    }
}

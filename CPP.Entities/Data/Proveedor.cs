using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("proveedor")]
    public class Proveedor : IEntity
    {
        [Column("proveedor_id")]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string nombre { get; set; }

        [Required]
        [StringLength(500)]
        public string direccion { get; set; }

        [Required]
        [StringLength(15)]
        public string rfc { get; set; }

        [StringLength(6)]
        public string codigo_postal { get; set; }

        [Required]
        [StringLength(25)]
        public string telefono { get; set; }

        [Required]
        public int dias_credito { get; set; }

        public string correo { get; set; }

        public bool activo { get; set; }
        [Required]

        [ForeignKey("FormaPago")]
        public int forma_pago_id { get; set; }

        public FormaPago forma_pago { get; set; }

        [ForeignKey("TipoProveedor")]
        public int tipo_proveedor_id { get; set; }

        public TipoProveedor tipo_proveedor { get; set; }
 
        public virtual List<ProveedorContacto> proveedor_contacto { get; set; }

        public virtual List<Remision> remisiones { get; set; }

        [NotMapped]
        public string forma_pago_descripcion { get; set; }

        [NotMapped]
        public string tipo_proveedor_descripcion { get; set; }

    }
}

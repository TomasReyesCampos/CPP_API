using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("remision")]
    public class Remision : IEntity
    {
        [Key]
        [Column("remision_id")]
        public int Id { get; set; }
 
        [ForeignKey("proveedor")]
        public int proveedor_id { get; set; }

        [ForeignKey("estado_remision")]
        public int estado_remision_id { get; set; }

        [ForeignKey("sucursal")]
        public int sucursal_id { get; set; }
        
        [ForeignKey("orden")]
        public int orden_id { get; set; }

        [Required]       
        public float cantidad { get; set; }

        [Required]
        public DateTime fecha_remision { get; set; }

        [Required]
        public DateTime fecha_pago { get; set; }

        [NotMapped]
        public DateTime fecha_alta { get; set; }

        [Required]
        public string comentarios { get; set; }

        public DateTime fecha_real_pago { get; set; }

        public bool activo { get; set; }

        public virtual EstadoRemision estado_remision { get; set; }

        public virtual Proveedor proveedor { get; set; }

        public virtual Sucursal sucursal { get; set; }
        public virtual Ordenes orden { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("orden")]
    public class Ordenes
    {
        [Key]
        [Column("orden_id")]
        public int Id { get; set; }

        [ForeignKey("estado_remision")]
        public int estado_orden_id { get; set; }

        [ForeignKey("proveedor")]
        public int proveedor_id { get; set; }

        [Required]
        public DateTime fecha_alta { get; set; }

        public DateTime fecha_pago { get; set; }

        public string persona_recibe { get; set; }

        public string numero_transferencia { get; set; }

        public string banco { get; set; }

        public string numero_cheque { get; set; }

        public string comentarios { get; set; }

        public virtual Proveedor proveedor { get; set; }

        public virtual EstadoOrden estado_remision { get; set; }
         
        public virtual List<Remision> remisiones { get; set; }

        [NotMapped]
        public string usuario { get; set; }

        public string usuario_autoriza { get; set; }
    }
}

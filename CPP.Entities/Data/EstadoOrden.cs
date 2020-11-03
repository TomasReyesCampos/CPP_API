using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("estado_orden")]
    public class EstadoOrden : IEntity
    {
        [Column("estado_orden_id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string estado_orden { get; set; }

    }
}

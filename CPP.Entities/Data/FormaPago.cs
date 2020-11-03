using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("forma_pago")]
    public class FormaPago : IEntity
    {
        [Column("forma_pago_id")]
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string forma_pago { get; set; }       
        public bool activo { get; set; }  
        public virtual Proveedor proveedor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("estado_remision")]
    public class EstadoRemision : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string estado_remision { get; set; }

        public virtual Remision remision { get; set; }
    }
}

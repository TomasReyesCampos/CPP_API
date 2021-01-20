using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("rol")]
    public class Rol : IEntity
    {
        [Key]
        [Column("rol_id")]
        public int Id { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        public bool activo { get; set; }

        public virtual Usuario usuario { get; set; }
    }
}

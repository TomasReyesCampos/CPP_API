using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("usuario")]
    public class Usuario : IEntity
    {
        [Key]
        [Column("usuario_id")]
        public int Id { get; set; }

        [ForeignKey("rol")]
        public int rol_id { get; set; }

        [Column("usuario")]
        public string user { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [ForeignKey("sucursal")]
        public int sucursal_id { get; set; }

        public bool activo { get; set; }
        public virtual Sucursal sucursal { get; set; }
        public virtual Rol rol { get; set; }
 
        [NotMapped]
        public bool testing { get; set; }
    }
}

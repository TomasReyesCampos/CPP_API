using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPP.Entities.Data
{
    [Table("sucursal")]
    public class Sucursal : IEntity
    {
        [Key]
        [Column("sucursal_id")]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string nombre { get; set; }

        [Required]
        [StringLength(150)]
        public string encargado { get; set; }

        public bool activo { get; set; }
    }
}

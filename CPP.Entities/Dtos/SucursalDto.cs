using CPP.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class SucursalDto : BaseDto, IEntity    
    {
        public int Id { get; set; } 
        public string nombre { get; set; }    
        public string encargado { get; set; }
        public bool activo { get; set; }
    }
}

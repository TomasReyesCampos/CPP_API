using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class OrdenPagarDto
    {
        public int id { get; set; }

        public string persona_recibe { get; set; }

        public string numero_transferencia { get; set; }

        public string banco { get; set; }

        public string numero_cheque { get; set; }

        public string comentarios { get; set; }
    }
}

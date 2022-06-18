using System;
using System.Collections.Generic;
using System.Text;

namespace ViveroDTO
{
    public class DTOItem
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; } 
        public DTOPlanta Planta { get; set; }
    }
}

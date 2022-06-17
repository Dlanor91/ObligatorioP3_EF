using System;
using System.Collections.Generic;
using System.Text;

namespace ViveroDTO
{
    public class DTOCompra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalCompra { get; set; }
        public string NombreCientifico { get; set; }
        public int Cantidad { get; set; }
    }
}

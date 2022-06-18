using System;
using System.Collections.Generic;
using System.Text;

namespace ViveroDTO
{
    public class DTOCompra
    {
        //Atributos de la Compra
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalCompra { get; set; }
        
        public IEnumerable<DTOItem> Items { get; set; }

        //Importacion
        public bool OrigenAmericaSur { get; set; }
        public string DescripcionSanitaria { get; set; }
        public int TasaDGI { get; set; }
        public int TasaAmericaSur { get; set; }

        //Plaza
        public decimal CostoFlete { get; set; }
        public int TasaIva { get; set; }

    }
}

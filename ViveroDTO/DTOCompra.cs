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
        public string DescripcionSanitaria { get; set; }

        //Plaza
        public decimal CostoFlete { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero
{
    public class Importacion:Compra
    {
        public static decimal tasaImportacionDGI { get; set; }

        public bool origenAmericaSur { get; set; }

        public static decimal descuentoAmericaSur { get; set; }

        public string descripcionSanitaria { get; set; }

        public override decimal PrecioFinal()
        {
            throw new NotImplementedException();
        }

        public override bool CompraValida()
        {
            throw new NotImplementedException();
        }
    }
}
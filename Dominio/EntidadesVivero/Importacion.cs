using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesVivero
{
    [Table("Importacion")]
    public class Importacion:Compra
    {
        public static decimal TasaImportacionDGI { get; set; }

        public bool OrigenAmericaSur { get; set; }

        public static decimal DescuentoAmericaSur { get; set; }

        public string DescripcionSanitaria { get; set; }

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
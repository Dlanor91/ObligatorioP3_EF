using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesVivero
{
    [Table("Plaza")]
	public class Plaza : Compra
    {  
        public decimal CostoFlete { get; set; }

        public override decimal PrecioFinal()
        {
            throw new NotImplementedException();
        }
    }
}
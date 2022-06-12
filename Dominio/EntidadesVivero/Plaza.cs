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
    
    [Required]	
    public decimal CostoFlete { get; set; }

        public override bool CompraValida()
        {
            throw new NotImplementedException();
        }

        public override decimal PrecioFinal()
        {
            throw new NotImplementedException();
        }
    }
}
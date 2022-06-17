using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesVivero
{
    [Table("Plaza")]
	public class Plaza : Compra, IValidar 
    {  
        public decimal CostoFlete { get; set; }

        public override decimal PrecioFinal()
        {

            //precio final = Sum de Item(cant*precioUnico) + CostoFlete
            throw new NotImplementedException();
        }

        public bool Validar()
        {
            bool ret = false;

            if (Fecha != null)
            {
                if (Item != null)
                {
                    foreach (var it in Item)
                    {
                        if (it.Planta == null)
                        {
                            return ret;
                        }
                    }

                    ret = true;
                }

            }

            return ret;
        }

        public bool ValidarDescripcion(string descripcion, int minimoDesc, int maxDesc)
        {
            throw new NotImplementedException();
        }

        public bool ValidarFormatoNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
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
        private decimal tasaIVA;
        public decimal TasaIVA
        {            
            set { tasaIVA = value; }
        }

        public override decimal PrecioFinal(decimal TasaIVA)
        {
            decimal PrecioFinalPlaza =0;            
            foreach (var it in Item)
            {
                PrecioFinalPlaza += it.PrecioUnitario * it.Cantidad;
            }
            
            if (PrecioFinalPlaza>0) {
                PrecioFinalPlaza += CostoFlete;                
            }

            return PrecioFinalPlaza;
        }

        public bool Validar()
        {
            bool ret = false;

            if (Fecha < DateTime.Now && Fecha != null && CostoFlete > 0)
            {
                if (Item != null)
                {
                    foreach (var it in Item)
                    {
                        if (it.PlantaId == null)
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
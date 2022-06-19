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
        private static int tasaIVA;
        public int TasaIVA { get { return tasaIVA; } }
        
        public override decimal PrecioFinal()
        {           
            decimal PrecioFinalPlaza =0;            
            foreach (var it in Items)
            {
                PrecioFinalPlaza += PrecioFinalPlaza * it.Cantidad;
            }
            
            if (PrecioFinalPlaza>0) {
                PrecioFinalPlaza += CostoFlete;
                PrecioFinalPlaza = PrecioFinalPlaza + PrecioFinalPlaza* TasaIVA/100;
            }
          
            return PrecioFinalPlaza;
        }

        public override decimal calcPRecio => PrecioFinalCalculado = PrecioFinal();
        public bool Validar()
        {
            bool ret = false;

            if (Fecha < DateTime.Now && Fecha != null && CostoFlete > 0)
            {
                if (Items != null)
                {
                    foreach (var it in Items)
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

        public static void nuevaTasaIVA(int ntIVA) {
            tasaIVA = ntIVA;
        }
    }
}
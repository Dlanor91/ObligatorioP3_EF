using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesVivero
{
    [Table("Importacion")]
    public class Importacion:Compra, IValidar
    {
        public bool OrigenAmericaSur { get; set; }        
       
        public string DescripcionSanitaria { get; set; }

        private static int tasaDGI;
        public int TasaDGI { get { return tasaDGI; } }

        private static int tasaAmericaSur;
        public int TasaAmericaSur { get { return tasaAmericaSur; } }       


        public override decimal PrecioFinal()
        {
            decimal PrecioFinalImp = 0;
            
            foreach (var it in Items)
            {
                PrecioFinalImp += it.PrecioUnitario * it.Cantidad;
            }
            if (PrecioFinalImp >0)
            {
                PrecioFinalImp = PrecioFinalImp + PrecioFinalImp * TasaDGI;
                if (OrigenAmericaSur)
                {
                    PrecioFinalImp = PrecioFinalImp - PrecioFinalImp * TasaAmericaSur;
                }
            }
            
            return PrecioFinalImp;
        }
        
        public bool Validar()
        {
            bool ret = false;

            if (Fecha < DateTime.Now && Fecha != null && DescripcionSanitaria != null)
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

        public static void nuevaTasaDGI(int ntDGI)
        {
            tasaDGI = ntDGI;
        }
        public static void nuevaTasaAmericaSUR(int ntAmSur)
        {
            tasaAmericaSur = ntAmSur;
        }
    }
}
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
        
        public override decimal PrecioFinal(decimal TasaIVA)
        {
            decimal PrecioFinalPlaza = 0;
            
            foreach (var it in Item)
            {
                PrecioFinalPlaza += it.PrecioUnitario * it.Cantidad;
            }

            
            return PrecioFinalPlaza;
        }

        public bool Validar()
        {
            bool ret = false;

            if (Fecha < DateTime.Now && Fecha != null && DescripcionSanitaria != null)
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
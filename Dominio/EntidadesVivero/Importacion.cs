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
        
        public override decimal PrecioFinal()
        {
            throw new NotImplementedException();
        }

        public bool Validar()
        {
            bool ret = false;

            if (Fecha != null && DescripcionSanitaria != null && OrigenAmericaSur != null)
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
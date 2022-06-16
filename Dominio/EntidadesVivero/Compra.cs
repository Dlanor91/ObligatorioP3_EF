using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesVivero
{
    [Table("Compra")]
    public abstract class Compra :IValidar
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public IEnumerable<Item> Item { get; set; }

        public abstract decimal PrecioFinal();        

        public bool Validar()
        {
            bool ret = false;   
             
            if( Fecha != null)
            {
                if(Item != null)
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

        public bool ValidarFormatoNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public bool ValidarDescripcion(string descripcion, int minimoDesc, int maxDesc)
        {
            throw new NotImplementedException();
        }
    }
}

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
        public abstract bool CompraValida();

        public bool Validar()
        {
            bool ret = false;   
            // falta validacion de id de compras duplicados
            if( Fecha != null)
            {
                if(Item != null)
                {
                    foreach (var it in Item)
                    {
                        if (it.Planta.NombreCientifico == null)
                        {
                            // si llega a este punto no debe continuar y  debe retornar false
                            return ret;
                        }
                    }
                    // caso positivo
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

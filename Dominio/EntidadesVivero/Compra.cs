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
            return true;
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

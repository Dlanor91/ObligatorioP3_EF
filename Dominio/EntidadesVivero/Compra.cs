using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesVivero
{
    [Table("Compra")]
    public abstract class Compra
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public decimal PrecioFinalCalculado { get; set; }
        public abstract decimal PrecioFinal();
                
    }
}

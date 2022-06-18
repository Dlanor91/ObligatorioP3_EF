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

        private static decimal precioFinalCalculado;
        public decimal PrecioFinalCalculado { get { return precioFinalCalculado; } }   

        public abstract decimal PrecioFinal();
        
        public static void nuevoPrecioFinal(decimal PrecioCalculado)
        {
            precioFinalCalculado = PrecioCalculado;
        }

    }
}

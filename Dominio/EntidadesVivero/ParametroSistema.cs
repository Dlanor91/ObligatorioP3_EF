using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesVivero
{
    [Table("ParametroSistema")]
    public class ParametroSistema
    {
        public decimal TasaIVA { get; set; }
        public decimal TasaImportacionDGI { get; set; }
        public decimal DescuentoAmericaSur { get; set; }
        public int ValorMinimoDescripcion { get; set; }
        public int ValorMaximoDescripcion { get; set; }
    }
}

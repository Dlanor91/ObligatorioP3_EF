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
        public int Id { get; set; }
        public int TasaIVA { get; set; }
        public int TasaImportacionDGI { get; set; }
        public int TasaDescuentoAmericaSur { get; set; }
        public int ValorMinimoDescripcionPL { get; set; }
        public int ValorMaximoDescripcionPL { get; set; }
        public int ValorMinimoDescripcionTP { get; set; }
        public int ValorMaximoDescripcionTP { get; set; }
    }
}

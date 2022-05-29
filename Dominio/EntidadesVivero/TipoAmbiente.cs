using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesVivero
{
    [Table("TipoAmbiente")]
    public class TipoAmbiente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Ambiente { get; set; }
    }
}

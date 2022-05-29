using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesVivero
{
	[Table("Iluminacion")]
	public class Iluminacion
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string TipoIluminacion { get; set; }
    }
}

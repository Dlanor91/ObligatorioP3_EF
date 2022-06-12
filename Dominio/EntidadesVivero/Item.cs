using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dominio.EntidadesVivero
{
	[Table("Item")]
	public class Item
	{
	[Key]
	public int Id { get; set; }

	public int Cantidad { get; set; }

	public decimal PrecioUnitario { get; set; }
	[ForeignKey("Planta")]	
	public Planta PlantaId { get; set; }

	}
}
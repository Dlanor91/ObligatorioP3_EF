using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace Dominio.EntidadesVivero
{
    [Table("Planta")]
    public class Planta :IValidar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCientifico { get; set; }
        [Required] [StringLength(500, MinimumLength = 10, ErrorMessage = "La descripción debe estar entre 10 y 500 caracteres.")]
        public string Descripcion { get; set; }
        [Required]
        public decimal AlturaMax { get; set; }
        [Required]
        public string Foto { get; set; }
        [Required]
        public TipoAmbiente TipoAmbiente { get; set; }
        [Required]
        public string FrecuenciaRiego { get; set; }
        [Required]
        public decimal Temperatura { get; set; }
        [Required]
        public TipoPlanta TipoPlanta { get; set; }
        [Required]
        public Iluminacion TipoIlumincacion { get; set; }
        [Required]
        public string NombresVulgares { get; set; }

        public bool Equals([AllowNull] Planta other)
        {
            if (other ==null)
                return false;
            return other.NombreCientifico.ToUpper().Trim()
                .Equals(this.NombreCientifico.ToUpper().Trim());
        }

        public bool Validar()
        {
            bool plantaValida = false;

            if (NombreCientifico != null && Descripcion != null && FrecuenciaRiego != null && NombresVulgares != null)
            {
                plantaValida = true;
            }

            return plantaValida;
        }


        public bool ValidarDescripcion(string descripcion, int minimoDesc, int maxDesc)
        {
            bool descripcionValida = false;

            if (descripcion.Length >= minimoDesc && descripcion.Length <= maxDesc)
            {
                descripcionValida = true;
            }

            return descripcionValida;
        }


        public bool ValidarFormatoNombre(string nombre)
        {
            bool errorFormato = false;

            if (nombre.Substring(0, 1) == " " || nombre.Substring(nombre.Length - 1, 1) == " ")
            {
                errorFormato = true;
            }
            else
            {
                for (int i = 0; i < nombre.Length && !errorFormato; i++)
                {
                    if (Char.IsNumber(nombre[i]) && Char.IsNumber(nombre[i]))
                    {
                        errorFormato = true;
                    }
                }
            }

            return errorFormato;
        }
    }
}
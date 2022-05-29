using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dominio.EntidadesVivero
{
    [Table("TipoPlanta")]
    public class TipoPlanta : IValidar
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public string Nombre { get; set; }
        [Required] [StringLength(200, MinimumLength = 10, ErrorMessage = "La descripción debe estar entre 10 y 200 caracteres.")]
        public string Descripcion { get; set; }

        public bool Equals([AllowNull] TipoPlanta other)
        {
            if (other ==null)
                return false;
            return other.Nombre.ToUpper().Trim()
                .Equals(this.Nombre.ToUpper().Trim());
        }

        public bool Validar()
        {
            bool valido = false;
            if (Nombre != null && Descripcion!= null)
            {
                valido = true;
            }

            return valido;
        }
               
        public bool ValidarDescripcion(string descripcion, int minimoDesc, int maxDesc)
        {
            bool descripcionValida = false;
            if (descripcion.Length>=minimoDesc && descripcion.Length<=maxDesc) {
                descripcionValida = true;
            } 
            return descripcionValida;
        }

        public bool ValidarFormatoNombre(string nombre)
        {
          bool errorFormato = false;

            if (nombre.Substring(0, 1) ==" " || nombre.Substring(nombre.Length-1, 1) ==" ")
            {
                errorFormato = true;
            }
            else
            {
                for (int i = 0; i<nombre.Length && !errorFormato; i++)
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

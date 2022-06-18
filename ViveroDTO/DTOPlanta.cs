using System;
using System.Collections.Generic;
using System.Text;

namespace ViveroDTO
{
    public class DTOPlanta
    {
        public string NombreCientifico { get; set; }        
        public string Descripcion { get; set; }       
        public decimal AlturaMax { get; set; }        
        public string Foto { get; set; }        
        public DTOTipoAmbiente TipoAmbiente { get; set; }       
        public string FrecuenciaRiego { get; set; }        
        public decimal Temperatura { get; set; }        
        public DTOTipoPlanta TipoPlanta { get; set; }       
        public DTOIluminacion TipoIluminacion { get; set; }        
        public string NombresVulgares { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero
{
    public class Planta :IValidar
    {
        public int id { get; set; }

        public string nombreCientifico { get; set; }

        public string descripcionPlanta { get; set; }

        public decimal alturaMax { get; set; }

        public string foto { get; set; }

        public TipoAmbiente tipoAmbiente { get; set; }

        public string frecuenciaRiego { get; set; }

        public decimal temperatura { get; set; }

        public TipoPlanta tipoPlanta { get; set; }

        public Iluminacion tipoIlumincacion { get; set; }

        public string nombresVulgares { get; set; }

        public bool Validar()
        {
            throw new NotImplementedException();
        }

        public bool ValidarFormatoNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}

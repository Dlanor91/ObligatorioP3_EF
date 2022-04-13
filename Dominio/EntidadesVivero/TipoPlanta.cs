using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero
{
    public class TipoPlanta : IValidar
    {
        public int id { get; set;}

        public string nombre { get; set; }

        public string descripcionTipo { get; set; }

        public bool Validar()
        {
            bool valido = false;
            if (nombre != null && descripcionTipo!= null)
            {
                valido = true;
            }

            return valido;
        }
    }
    
}

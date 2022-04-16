using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorIluminacion
    {
        public IEnumerable<Iluminacion> MostrarTodasIluminaciones();
        bool AgregarTipoPlanta(Iluminacion il);
    }
}

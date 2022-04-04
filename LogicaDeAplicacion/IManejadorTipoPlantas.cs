using Dominio.EntidadesVivero;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;

namespace LogicaDeAplicacion
{
    public interface IManejadorTipoPlantas
    {
        bool AgregarTipoPlanta(TipoPlanta tp);
    }
}

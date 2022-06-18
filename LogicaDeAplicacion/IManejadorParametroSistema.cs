using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorParametroSistema
    {    
        IEnumerable<ParametroSistema> TodosLosParametros();
        bool AltaParametros(ParametroSistema ps);
        ParametroSistema ParametrosFilaUno();
    }
}

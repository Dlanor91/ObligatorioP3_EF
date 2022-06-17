using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorParametroSistema
    {
        public int descMaxima();
        public int descMinima();

        public IEnumerable<ParametroSistema> TodosLosParametros();
        public ParametroSistema ParametrosFilaUno();
    }
}

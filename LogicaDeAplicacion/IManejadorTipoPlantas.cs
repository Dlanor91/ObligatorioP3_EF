using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorTipoPlantas
    {
        IEnumerable<TipoPlanta> MostrarTodosTiposPlantas();
        bool AgregarTipoPlanta(TipoPlanta tp);             
        TipoPlanta buscarUnaPlanta(int id);
        TipoPlanta buscarPlantaNombre(string nombreTP);
        bool actDescripcionTipoPlanta(TipoPlanta tp);
        bool eliminarTipoPlanta(int id);

    }
}

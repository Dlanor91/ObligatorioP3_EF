using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorPlanta
    {
        IEnumerable<Planta> MostrarTodasPlantas();
        IEnumerable<Planta> BusquedaNombre(string nombreBusqPlanta);
        IEnumerable<Planta> buscarPlantasMenoresAlt(decimal alturaBuscar);
        IEnumerable<Planta> buscarPlantasMayoresAlt(decimal alturaBuscar);
        IEnumerable<Planta> buscarPlantasTipoAmbiente(int idTipoAmbiente);
        IEnumerable<Planta> buscarPlantasTipoPlanta(int idTipoPlanta);
        IEnumerable<TipoPlanta> TraerTodosTiposPlantas();
        IEnumerable<TipoAmbiente> TraerTodosTiposAmbientes();
        IEnumerable<Iluminacion> TraerTodosIluminaciones();
        bool AgregarPlanta(Planta p, int idTipoPlanta, int idTipoAmbiente, int idIluminacion);
        bool verificarNombreC(string nombreC);
        Planta TraerPlanta(int id);
    }
}
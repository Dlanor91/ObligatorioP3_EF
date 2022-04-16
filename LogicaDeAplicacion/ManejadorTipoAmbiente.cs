using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using Repositorios;

namespace LogicaDeAplicacion
{
    public class ManejadorTipoAmbiente : IManejadorTipoAmbiente
    {
        public IRepositorioTipoAmbiente RepoTipoAmbiente { get; set; }

        public ManejadorTipoAmbiente(IRepositorioTipoAmbiente repoTipoAmbiente)
        {
            RepoTipoAmbiente=repoTipoAmbiente;
        }

        public IEnumerable<TipoAmbiente> MostrarTodosTipoAmbiente()
        {
            return RepoTipoAmbiente.FindAll();
        }
    }
}

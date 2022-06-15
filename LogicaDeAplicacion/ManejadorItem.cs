using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using Repositorios;

namespace LogicaDeAplicacion
{
    public class ManejadorItem : IManejadorItem
    {
        public IRepositorioItems RepoItem { get; set; }

        public ManejadorItem(IRepositorioItems repoItem)
        {
            RepoItem=repoItem;
        }
    }
}

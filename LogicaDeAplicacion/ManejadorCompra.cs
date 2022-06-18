using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using Repositorios;

namespace LogicaDeAplicacion
{
    public class ManejadorCompra: IManejadorCompra
    {
        public IRepositorioPlantas RepoPlantas { get; set; }
        public IRepositorioItems RepoItem { get; set; }
        public IRepositorioCompra RepoCompra { get; set; }
        public IRepositorioParametroSistema RepoPS { get; set; }

        public ManejadorCompra(IRepositorioPlantas repoPlantas, IRepositorioItems repoItem, IRepositorioCompra repoCompra, IRepositorioParametroSistema repoPS)
        {
            RepoPlantas=repoPlantas;
            RepoItem=repoItem;
            RepoCompra=repoCompra;
            RepoPS=repoPS;
        }

        public IEnumerable<Compra> MostrarTodasCompras()
        {
            return RepoCompra.FindAll();
        }

        public bool AgregarCompra(Compra cp)
        {
            return RepoCompra.Add(cp);
        }

        public Compra MostrarCompraId(int id)
        {
            return RepoCompra.FindById(id);
        }

        public IEnumerable<Compra> MostrarComprarPorIdPlanta(int idPlanta)
        {
            return RepoCompra.BuscarComprasPorIdTipoPlanta(idPlanta);
        }
    }
}

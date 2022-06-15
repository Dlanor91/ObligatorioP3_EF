﻿using System;
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

        public ManejadorCompra(IRepositorioPlantas repoPlantas, IRepositorioItems repoItem, IRepositorioCompra repoCompra)
        {
            RepoPlantas=repoPlantas;
            RepoItem=repoItem;
            RepoCompra=repoCompra;
        }

        public IEnumerable<Compra> MostrarTodasCompras()
        {
            return RepoCompra.FindAll();
        }
    }
}

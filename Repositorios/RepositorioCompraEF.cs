using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Repositorios
{
    public class RepositorioCompraEF : IRepositorioCompra
    {
        public ViveroContext Contexto { get; set; }

        public RepositorioCompraEF(ViveroContext cont)
        {
            Contexto = cont;
        }
        public bool Add(Compra obj)
        {
            Contexto.Compras.Add(obj);
            return Contexto.SaveChanges() >=1;
        }

        public bool Remove(int id)
        {            
            throw new NotImplementedException();            
        }

        public bool Update(Compra obj)
        {
            Contexto.Compras.Update(obj);
            return Contexto.SaveChanges()>=1;
        }

        public IEnumerable<Compra> FindAll()
        {
            return Contexto.Compras.ToList();
        }

        public Compra FindById(int id)
        {
            return Contexto.Compras.Find(id);
        }
    }
    
}
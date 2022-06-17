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
using Microsoft.EntityFrameworkCore; 


namespace Repositorios
{
    public class RepositorioCompraEF : IRepositorioCompra
    {
        public IRepositorioItems RepositorioItems { get; set; }
        public ViveroContext Contexto { get; set; }

        public RepositorioCompraEF(IRepositorioItems repositorioItems, ViveroContext contexto)
        {
            RepositorioItems=repositorioItems;
            Contexto=contexto;
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
            return Contexto.Compras.Include(c=> c.Item)
                                   .ThenInclude(it=>it.Planta )                                   
                                   .ThenInclude(pl=>pl.TipoPlanta)
                                   .Include(c => c.Item)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoIlumincacion)
                                   .Include(c => c.Item)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoAmbiente)
                                   .ToList();
        }

        public Compra FindById(int id)
        {
            return Contexto.Compras.Include(c => c.Item)
                                   .ThenInclude(it => it.Planta)                                   
                                   .ThenInclude(pl => pl.TipoPlanta)
                                   .Include(c => c.Item)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoIlumincacion)
                                   .Include(c => c.Item)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoAmbiente)
                                   .Where(cp => cp.Id == id)
                                   .SingleOrDefault();
        }

        public IEnumerable<Compra> BuscarComprasPorIdPlanta(int idPlanta)
        {
            return Contexto.Compras.Include(c => c.Item)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoPlanta)
                                   .Include(c => c.Item)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoIlumincacion)
                                   .Include(c => c.Item)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoAmbiente)
                                   .Where(c => c.Item.Any(pl => pl.PlantaId == idPlanta))
                                   .ToList();

        }
    }
    
}
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
            Compra cp = Contexto.Compras.Find(id);
            if (cp == null) return false;
            Contexto.Compras.Remove(cp);
            return Contexto.SaveChanges() >= 1;
        }

        public bool Update(Compra obj)
        {
            Contexto.Compras.Update(obj);
            return Contexto.SaveChanges()>=1;
        }

        public IEnumerable<Compra> FindAll()
        {
            return Contexto.Compras.Include(c=> c.Items)
                                   .ThenInclude(it=>it.Planta )                                   
                                   .ThenInclude(pl=>pl.TipoPlanta)
                                   .Include(c => c.Items)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoIluminacion)
                                   .Include(c => c.Items)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoAmbiente)
                                   .ToList();
        }

        public Compra FindById(int id)
        {
            return Contexto.Compras.Include(c => c.Items)
                                   .ThenInclude(it => it.Planta)                                   
                                   .ThenInclude(pl => pl.TipoPlanta)
                                   .Include(c => c.Items)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoIluminacion)
                                   .Include(c => c.Items)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoAmbiente)
                                   .Where(cp => cp.Id == id)
                                   .SingleOrDefault();
        }

        public IEnumerable<Compra> BuscarComprasPorIdTipoPlanta(int idTipoPlanta)
        {
            return Contexto.Compras.Include(c => c.Items)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoPlanta)
                                   .Include(c => c.Items)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoIluminacion)
                                   .Include(c => c.Items)
                                   .ThenInclude(it => it.Planta)
                                   .ThenInclude(pl => pl.TipoAmbiente)
                                   .Where(c => c.Items.Any(pl => pl.Planta.TipoPlanta.Id == idTipoPlanta))
                                   .ToList();

        }

        public ParametroSistema CargarParametrosSistema()
        {
            ParametroSistema ps = Contexto.ParametroSistema.FirstOrDefault();
            
            return ps;
        }
    }
    
}
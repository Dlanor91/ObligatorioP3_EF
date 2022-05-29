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

    public class RepositorioTipoPlantaEF : IRepositorioTipoPlanta   

    {
        public ViveroContext Contexto { get; set; }

        public RepositorioTipoPlantaEF(ViveroContext cont)
        {
            Contexto = cont;
        }
        public bool Add(TipoPlanta obj)
        {
            Contexto.TipoPlantas.Add(obj);
            return Contexto.SaveChanges() >=1;
        }
        
        public TipoPlanta buscarTipoPlanta(string nombreTipo)
        {
            return Contexto.TipoPlantas.Where(tp => tp.Nombre == nombreTipo).SingleOrDefault(); 
        }          

        public bool existeNombre(string nombreTipoPlanta)
        {
            //Contexto.TipoPlantas.Where(tp => tp.Nombre == nombreTipoPlanta);
            return true;
        }

        public IEnumerable<TipoPlanta> FindAll()
        {
            return Contexto.TipoPlantas.ToList();
        }

        public TipoPlanta FindById(int id)
        {
            return Contexto.TipoPlantas.Find(id);
        }        

        public bool Remove(int id)
        {
            Contexto.TipoPlantas.Remove(new TipoPlanta() { Id = id});
            return Contexto.SaveChanges() >=1;
        }

        public bool Update(TipoPlanta obj)
        {
            Contexto.TipoPlantas.Update(obj);
            return Contexto.SaveChanges()>=1;
        }
    }
}

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
    public class RepositorioTipoAmbienteEF : IRepositorioTipoAmbiente
    {
        
        public ViveroContext Contexto { get; set; }

        public RepositorioTipoAmbienteEF(ViveroContext cont)
        {
            Contexto = cont;
        }
     
        public bool Add(TipoAmbiente obj)
        {
            Contexto.TipoAmbientes.Add(obj);
            return Contexto.SaveChanges() >=1;
        }


        public IEnumerable<TipoAmbiente> FindAll()
        {
            return Contexto.TipoAmbientes.ToList();
        }

        public TipoAmbiente FindById(int id)
        {
            return Contexto.TipoAmbientes.Find(id);
        }

        public bool Remove(int id)
        {
            Contexto.TipoAmbientes.Remove(new TipoAmbiente() { Id = id});
            return Contexto.SaveChanges() >=1;        }

        public bool Update(TipoAmbiente obj)
        {
            Contexto.TipoAmbientes.Update(obj);
            return Contexto.SaveChanges()>=1;
        }
    }
}

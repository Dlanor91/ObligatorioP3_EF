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
    public class RepositorioIluminacionEF : IRepositorioIluminacion
    {
        public ViveroContext Contexto { get; set; }
        public RepositorioIluminacionEF(ViveroContext cont)
        {
            Contexto = cont;
        }
        public bool Add(Iluminacion obj)
        {
            Contexto.Iluminaciones.Add(obj);
            return Contexto.SaveChanges() >=1;
        }

        public bool Remove(int id)
        {
            Contexto.Iluminaciones.Remove(new Iluminacion() { Id = id });
            return Contexto.SaveChanges() >=1;
        }

        public bool Update(Iluminacion obj)
        {
            Contexto.Iluminaciones.Update(obj);
            return Contexto.SaveChanges()>=1;
        }

        public IEnumerable<Iluminacion> FindAll()
        {
            return Contexto.Iluminaciones.ToList();
        }

        public Iluminacion FindById(int id)
        {
            return Contexto.Iluminaciones.Find(id);
        }
    }
}
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
    public class RepositorioParametroSistemaEF : IRepositorioParametroSistema
    {
        public ViveroContext Contexto { get; set; }

        public RepositorioParametroSistemaEF(ViveroContext cont)
        {
            Contexto = cont;
        }      

        public bool Add(ParametroSistema obj)
        {
            Contexto.ParametroSistema.Add(obj);
            return Contexto.SaveChanges() >=1;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ParametroSistema obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParametroSistema> FindAll()
        {
            return Contexto.ParametroSistema.ToList();
        }

        public ParametroSistema FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ParametroSistema TraerElementosFilaUno()
        {
            return Contexto.ParametroSistema.First();
        }              

    }
}

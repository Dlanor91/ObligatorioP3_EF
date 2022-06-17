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

        public int descripcionMax()
        {
            return Contexto.ParametroSistema.Select(ps => ps.ValorMaximoDescripcion).Single();
        }

        public int descripcionMin()
        {
            return Contexto.ParametroSistema.Select(ps => ps.ValorMinimoDescripcion).Single();
        }

        public bool Add(ParametroSistema obj)
        {
            throw new NotImplementedException();
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

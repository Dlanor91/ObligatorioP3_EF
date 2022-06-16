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

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using Repositorios;

namespace LogicaDeAplicacion
{
    public class ManejadorParametroSistema : IManejadorParametroSistema
    {
        public IRepositorioParametroSistema repoPS { get; set; }

        public ManejadorParametroSistema(IRepositorioParametroSistema repoParametroSistema) {

            repoPS = repoParametroSistema;
        }
        
        public IEnumerable<ParametroSistema> TodosLosParametros()
        {
            return repoPS.FindAll();
        }

        public ParametroSistema ParametrosFilaUno()
        {
            return repoPS.TraerElementosFilaUno();
        }

        public bool AltaParametros(ParametroSistema ps)
        {
            return repoPS.Add(ps);
        }

    }
}

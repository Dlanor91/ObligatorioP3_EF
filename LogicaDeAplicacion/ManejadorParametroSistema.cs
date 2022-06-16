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
        public int descMaxima()
        {
            return repoPS.descripcionMax();
        }

        public int descMinima()
        {
            return repoPS.descripcionMin();
        }
    }
}

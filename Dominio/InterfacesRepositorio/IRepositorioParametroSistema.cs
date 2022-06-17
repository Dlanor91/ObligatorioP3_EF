using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioParametroSistema : IRepositorio<ParametroSistema>
    {
        public int descripcionMin();
        public int descripcionMax();
    }
}

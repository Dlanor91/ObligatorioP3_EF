using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorCompra
    {
        public IEnumerable<Compra> MostrarTodasCompras();
        bool AgregarCompra(Compra cp);

        public Compra MostrarCompraId(int id);
    }
}

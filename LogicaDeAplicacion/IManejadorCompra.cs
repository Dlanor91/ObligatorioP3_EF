using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorCompra
    {
        IEnumerable<Compra> MostrarTodasCompras();
        bool AgregarCompra(Compra cp);
        Compra MostrarCompraId(int id);
        void ParametrosCompra();
        IEnumerable<Compra> MostrarComprarPorIdPlanta(int idPlanta);
        bool EliminarCompra(int id);
    }
}

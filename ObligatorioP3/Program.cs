using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using LogicaDeAplicacion;
using System;
using Repositorios;

namespace ObligatorioP3
{
    class Program
    {
        static void Main(string[] args)
        {
            IManejadorTipoPlantas manejadorTP = FabricaDeManejadores.ObtenerManejadorPlanta();

            TipoPlanta tp = new TipoPlanta()
            {                
                nombre = "Planta2",
                descripcionTipo = "Descrip2",
                
            };
            bool ok = manejadorTP.AgregarTipoPlanta(tp);
            Console.WriteLine(ok);            
            Console.ReadLine();
        }
    }
}

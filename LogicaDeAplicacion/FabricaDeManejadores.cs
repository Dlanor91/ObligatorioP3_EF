using Dominio.EntidadesVivero;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Repositorios;
using Microsoft.Extensions.Configuration;

namespace LogicaDeAplicacion
{
    public class FabricaDeManejadores
    {
        public static IManejadorTipoPlantas ObtenerManejadorPlanta()
        {
            ManejadorTipoPlantas man = null;
            string tipoRepo = "";
            IRepositorioTipoPlanta repo;

            ConfigurationBuilder cb = new ConfigurationBuilder(); //creo la configuration para acceder al json aqui y en conexion
            cb.AddJsonFile("appsettings.json");
            IConfiguration configuracion = cb.Build(); //aqui lo construya

            tipoRepo = configuracion.GetSection("TipoRepos").Value;
            if (tipoRepo == "ADO")
            {
                repo = new RepositorioTipoPlantaADO();
            }
            else 
            {
                throw new Exception("No existe el tipo de repositorio o no fue especificado");
            }
            man = new ManejadorTipoPlantas(repo);
            return man;
        }
    }
}

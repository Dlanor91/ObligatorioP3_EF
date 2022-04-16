using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using Repositorios;

namespace LogicaDeAplicacion
{
    public class ManejadorIluminacion : IManejadorIluminacion
    {
        public IRepositorioIluminacion RepoIluminacion { get; set; }

        public ManejadorIluminacion(IRepositorioIluminacion repoIluminacion)
        {
            RepoIluminacion=repoIluminacion;
        }

        public IEnumerable<Iluminacion> MostrarTodasIluminaciones()
        {
            return RepoIluminacion.FindAll();
        }
        public bool AgregarTipoPlanta(Iluminacion il)
        {
            return RepoIluminacion.Add(il);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Repositorios;

namespace LogicaDeAplicacion
{
    public class ManejadorUsuario : IManejadorUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public ManejadorUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario=repoUsuario;
        }
                
        public Usuario IngresoExitoso(string nombreUsuario, string contrasenia)
        {
            return RepoUsuario.Ingreso(nombreUsuario, contrasenia);
        }
    }
}

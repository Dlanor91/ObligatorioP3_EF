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
                
        public Usuario IngresoExitoso(string emailUsuario, string contrasenia)
        {
            return RepoUsuario.Ingreso(emailUsuario, contrasenia);
        }

        public bool PrecargaUsuarios(string emailUsuario, string contrasenia)
        {            
            Usuario nuevoUsuario = new Usuario() { Email=emailUsuario, Contrasenia = contrasenia };
            
            return RepoUsuario.Add(nuevoUsuario); 
        }
    }
}

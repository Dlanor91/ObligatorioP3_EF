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

        public bool PrecargaUsuarios(Usuario user)
        {            
             return RepoUsuario.Add(user); 
        }

        public bool busquedadEmail(string buscarEmail)
        {
            return RepoUsuario.buscarEmailUsuario(buscarEmail);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorUsuario
    {
        public Usuario IngresoExitoso(string emailUsuario, string contrasenia);
        public bool PrecargaUsuarios(string emailUsuario, string contrasenia);
    }
}

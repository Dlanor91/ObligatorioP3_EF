using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorUsuario
    {
        Usuario IngresoExitoso(string emailUsuario, string contrasenia);
        bool PrecargaUsuarios(Usuario user);
        bool busquedadEmail(string buscarEmail);
    }
}

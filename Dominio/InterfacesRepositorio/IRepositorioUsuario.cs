using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
        public Usuario Ingreso(string email, string contrasenia);

        bool buscarEmailUsuario(string emailBuscado);
    }
}

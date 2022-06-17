﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero
{
    public interface IValidar
    {
        public bool Validar();        
        bool ValidarFormatoNombre(string nombre);
        bool ValidarDescripcion(string descripcion,int minimoDesc, int maxDesc);
    }
}

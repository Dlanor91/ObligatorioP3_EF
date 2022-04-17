﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero
{
    public interface IValidar
    {
        bool Validar();
        bool ValidarFormatoNombre(string nombre);
    }
}

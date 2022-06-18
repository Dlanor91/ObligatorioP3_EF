﻿using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorTipoAmbiente
    {
        IEnumerable<TipoAmbiente> MostrarTodosTipoAmbiente();
    }
}

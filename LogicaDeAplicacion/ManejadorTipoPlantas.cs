using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Repositorios;

namespace LogicaDeAplicacion
{
    public class ManejadorTipoPlantas : IManejadorTipoPlantas
    {
        public IRepositorioTipoPlanta RepoTipoPlantas { get; set; }

        public ManejadorTipoPlantas(IRepositorioTipoPlanta repoTipoPlantas)
        {
            RepoTipoPlantas=repoTipoPlantas;
        }
        
        public bool AgregarTipoPlanta(TipoPlanta tp)
        {           
            return RepoTipoPlantas.Add(tp);
        }

        public IEnumerable<TipoPlanta> MostrarTodosTiposPlantas()
        {
            return RepoTipoPlantas.FindAll();
        }

        public bool ValidarNombreUnico(string nombreTP)
        {
            return RepoTipoPlantas.existeNombre(nombreTP);
        }

        public bool ValidarFormatoNombre(string nombreTP)
        {
            bool nombreBien = false;

            if (nombreTP.Substring(0,1) ==" " || nombreTP.Substring(nombreTP.Length-1, 1) ==" ")
            {
                nombreBien = false;
            }
            else {
                nombreBien = true;                
                for (int i=0;i<nombreTP.Length && nombreBien; i++) {
                    if (Convert.ToInt32(nombreTP[i]) >= 0 && Convert.ToInt32(nombreTP[i]) <= 9) {
                        nombreBien = false;
                    }                    
                }                
            }

            return nombreBien;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;

namespace Repositorios
{

    public class RepositorioTipoPlantaADO : IRepositorioTipoPlanta   

    {
        public bool Add(TipoPlanta obj)
        {
            bool listo = false;

            SqlConnection conect = Conexion.ObtenerConexion();
            string sql = "INSERT INTO TipoPlanta VALUES(@nombre,@desc);";
            SqlCommand com = new SqlCommand(sql, conect);

            com.Parameters.AddWithValue("@nombre",obj.nombre);
            com.Parameters.AddWithValue("@desc", obj.descripcionTipo);

            SqlTransaction transaccion = null;

            try
            {
                Conexion.AbrirConexion(conect);
                transaccion = conect.BeginTransaction();
                com.Transaction = transaccion;
                int filasAfectadas = com.ExecuteNonQuery();
                listo = filasAfectadas == 1;
                transaccion.Commit();
                Conexion.CerrarConexion(conect);

            }
            catch
            {
                if (transaccion != null) transaccion.Rollback();
               
            }
            finally 
            {
                Conexion.CerrarYDisposeConexion(conect);
            }

            return listo;
        }
        
        public TipoPlanta buscarTipoPlanta(string nombreTipo)
        {
            throw new NotImplementedException();
        }

        public bool eliminarTipoPlanta(string nombreTipo)
        {
            bool listo = false;
            return listo;
        }

        public IEnumerable<TipoPlanta> FindAll()
        {
            throw new NotImplementedException();
        }

        public TipoPlanta FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool modificarDesripcionTipoPlanta(string nombreTipo)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }
    }
}

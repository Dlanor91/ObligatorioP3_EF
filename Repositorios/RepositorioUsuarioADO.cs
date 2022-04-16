using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;

namespace Repositorios
{
    public class RepositorioUsuarioADO : IRepositorioUsuario
    {
        public bool Add(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Ingreso(string email, string contrasenia)
        {
            Usuario ingresado = null;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Usuarios WHERE Email = @email and Contrasenia = @contrasenia;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@contrasenia", contrasenia);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    ingresado = new Usuario()
                    {
                        nombreUsuario = reader.GetString(1),
                        Email = reader.GetString(2),
                        Nombre = reader.GetString(4),
                        Apellido = reader.GetString(5),
                    };
                }

                Conexion.CerrarConexion(con);
            }
            catch
            {
                throw;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return ingresado;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}

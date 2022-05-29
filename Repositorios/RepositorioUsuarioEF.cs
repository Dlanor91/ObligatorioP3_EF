using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario

    {
        public ViveroContext Contexto { get; set; }
        public RepositorioUsuarioEF(ViveroContext cont)
        {
            Contexto = cont;
        }

        public bool Add(Usuario nuevoAutor)
        {
            Contexto.Usuarios.Add(nuevoAutor);
            return Contexto.SaveChanges() >= 1;
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios.Find(id);
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
                        Email = reader.GetString(1),                       
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
            Contexto.Usuarios.Remove(new Usuario() { Id = id });
            return Contexto.SaveChanges() >= 1;
        }

        public bool Update(Usuario obj)
        {
            Contexto.Usuarios.Update(obj);
            return Contexto.SaveChanges() >= 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Repositorios 
{

    public class RepositorioTipoPlantaEF : IRepositorioTipoPlanta   

    {
        public ViveroContext Contexto { get; set; }

        public RepositorioTipoPlantaEF(ViveroContext cont)
        {
            Contexto = cont;
        }
        public bool Add(TipoPlanta obj)
        {
            Contexto.TipoPlantas.Add(obj);
            return Contexto.SaveChanges() >=1;
        }
        
        public TipoPlanta buscarTipoPlanta(string nombreTipo)
        {
            TipoPlanta tipoPlantaBuscada = null;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TipoPlanta WHERE nombre=@nombreTipo;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@nombreTipo", nombreTipo);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    tipoPlantaBuscada = new TipoPlanta()
                    {
                        id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        descripcionTipo = reader.GetString(2)
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

            return tipoPlantaBuscada;
        }

       

        public bool existeNombre(string nombreTipoPlanta)
        {
            bool tipoPlantaBuscadaNombre = false;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TipoPlanta WHERE nombre=@nombreTipoPlanta;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@nombreTipoPlanta", nombreTipoPlanta);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    tipoPlantaBuscadaNombre = true;
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

            return tipoPlantaBuscadaNombre;
        }

        public IEnumerable<TipoPlanta> FindAll()
        {
            return Contexto.TipoPlantas.ToList();
        }

        public TipoPlanta FindById(int id)
        {
            return Contexto.TipoPlantas.Find(id);
        }
        

        public bool Remove(int id)
        {
            Contexto.TipoPlantas.Remove(new TipoPlanta() { Id = id});
            return Contexto.SaveChanges() >=1;
        }

        public bool Update(TipoPlanta obj)
        {
            Contexto.TipoPlantas.Update(obj);
            return Contexto.SaveChanges()>=1;
        }
    }
}

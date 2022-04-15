using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;

namespace Repositorios
{
    public class RepositorioPlantaADO : IRepositorioPlantas
    {
        public bool Add(Planta obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarAmbiente(int tipoAmbiente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarPlantaMayorAlt(decimal altura)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarPlantaMenorAlt(decimal altura)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarPlantaNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarTipoPlanta(int TipoPlanta)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> FindAll()
        {
            throw new NotImplementedException();
        }

        public Planta FindById(int id)
        { 
            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "select pl.id, pl.nombreCientifico, pl.descripcionPlanta, pl.alturaMax, pl.foto, ta.tipoAmbiente, pl.frecuenciaRiego, pl.temperatura, tp.nombre,il.tipoIluminacion,pl.nombreVulgares from Planta pl " +
                         "left join TipoAmbiente ta on pl.tipoAmbiente = ta.id " +
                         "left join TipoPlanta tp on pl.tipoPlanta = tp.id " +
                         "left join Iluminacion il on pl.tipoIluminacion = il.id " +
                         "where pl.id = @id; ";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", id);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {                    
                    Planta pl = CrearPlanta(reader);
                    pl.tipoAmbiente = CrearTipoAmbiente(reader);
                    pl.tipoPlanta = CrearTipoPlanta(reader);
                    pl.tipoIlumincacion = CrearIluminacion(reader);
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

            return plantaBuscada;
        }
             

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Planta obj)
        {
            throw new NotImplementedException();
        }
    }
}

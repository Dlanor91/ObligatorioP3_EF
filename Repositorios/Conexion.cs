using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Repositorios
{
    public class Conexion
    {
        public static string ObtenerCadenaConexion() 
        {
            string strConect = "";

            ConfigurationBuilder cb = new ConfigurationBuilder();
            cb.AddJsonFile("appsettings.json");
            IConfiguration configuracion = cb.Build();

            strConect = configuracion.GetConnectionString("ConexionADO");

            return strConect;
        }

        public static SqlConnection ObtenerConexion()
        {
            string strConect = ObtenerCadenaConexion();
            return new SqlConnection(strConect);
        }

        public static void AbrirConexion(SqlConnection con)
        {
            if (con!=null && con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }

        public static void CerrarYDisposeConexion(SqlConnection con)
        {
            CerrarConexion(con);
            con.Dispose();
        }

        public static void CerrarConexion(SqlConnection con)
        {
            if (con != null && con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
    }
}

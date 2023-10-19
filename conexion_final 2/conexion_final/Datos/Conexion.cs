using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace conexion_final.Datos
{
    public class Conexion
    {
        NpgsqlConnection conn = new NpgsqlConnection();

        private string cadena = string.Empty;
        static String servidor = "localhost";
        static String bd = "Reto_Final";
        static String user = "postgres";
        static String pass = "luis2415$";
        static String puerto = "5432";

        public Conexion()
        {
            cadena = "server=" + servidor + ";port=" + puerto + ";user id=" + user + ";password=" + pass + ";database=" + bd + ";";
        }
        public NpgsqlConnection AbrirConexion()
        {
            try
            {
                conn.ConnectionString = cadena;
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return conn;
        }
        public void CerrarConexion()
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}

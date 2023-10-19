using System;
using conexion_final.Models;
using Npgsql;
using System.Data;

namespace conexion_final.Datos
{
	public class ProfesorDatos
	{
        public List<Profesores> Consultar()
        {
            var oLista = new List<Profesores>();
            var con = new Conexion();
            try
            {
                string sql = "SELECT ProfesorID, Nombre, ApellidoP, ApellidoM, Correo,Contraseña FROM Profesores;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Profesores()
                        {
                            IdProfe=int.Parse(dr["ProfesorID"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Apellidop = dr["ApellidoP"].ToString(),
                            Apellidom = dr["ApellidoM"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Contraseña = dr["Contraseña"].ToString()
                        });
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return oLista;
        }
    }
}


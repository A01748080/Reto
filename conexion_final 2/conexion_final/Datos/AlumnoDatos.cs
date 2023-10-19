using System;
using conexion_final.Models;
using Npgsql;
using System.Data;

namespace conexion_final.Datos
{
	public class AlumnoDatos
	{
        public List<Alumnos> Consultar()
        {
            var oLista = new List<Alumnos>();
            var con = new Conexion();
            try
            {
                string sql = "SELECT AlumnoID, Nombre, ApellidoP, ApellidoM, Correo,Grupo,Contraseña FROM Alumnos;"; 
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Alumnos()
                        {
                            IdAlumno = int.Parse(dr["AlumnoID"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Apellidop = dr["ApellidoP"].ToString(),
                            Apellidom = dr["ApellidoM"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Grupo = int.Parse(dr["Grupo"].ToString()),
                            Contraseña = dr["Contraseña"].ToString()
                        }) ;
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


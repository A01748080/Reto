using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using conexion_final.Models;

namespace conexion_final.Datos
{
	public class UsuarioDatos
	{
        public List<UsuarioModel> Consultar()
        {
            var oLista = new List<UsuarioModel>();
            var con = new Conexion();
            try
            {
                string sql = "SELECT * FROM Alumnos;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new UsuarioModel()
                        {
                            Usuario = dr["Usuario"].ToString(),
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


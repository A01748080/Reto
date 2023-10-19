using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using conexion_final.Models;

namespace conexion_final.Datos
{
	public class AdminDatos
	{
        public List<AdminModel> Consultar()
        {
            var oLista = new List<AdminModel>();
            var con = new Conexion();
            try
            {
                string sql = "SELECT correo, contraseña FROM admin;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new AdminModel()
                        {
                            correo = dr["correo"].ToString(),
                            contraseña = dr["contraseña"].ToString()
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


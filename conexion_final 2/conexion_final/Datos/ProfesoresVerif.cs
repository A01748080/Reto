using System;
using conexion_final.Models;
using Npgsql;
using System.Data;

namespace conexion_final.Datos
{
	public class ProfesoresVerif
	{

        public List<ProfesoresAdminModel> Consultar()
        {
            var oLista = new List<ProfesoresAdminModel>();
            var con = new Conexion();
            try
            {
                string sql = "SELECT ProfesorID, Nombre, ApellidoP, ApellidoM, Correo FROM ProfesoresAdmin;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ProfesoresAdminModel()
                        {
                            IdProfe = int.Parse(dr["ProfesorID"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Apellidop = dr["ApellidoP"].ToString(),
                            Apellidom = dr["ApellidoM"].ToString(),
                            Correo = dr["Correo"].ToString(),
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


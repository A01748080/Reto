using System;
using System.Data;
using Npgsql;
using conexion_final.Models;

namespace conexion_final.Datos
{
    public class Manipulate
    {
        public Manipulate()
        {
        }

        public void Agregar(string nombre, string apellidop, string apellidom, string correo, string contraseña, int grado, int grupo)
        {
            // Utiliza el nombre correcto de la función de PostgreSQL para insertar un alumno.
            string sql = "CALL InsertarAlumno('" + nombre + "','" + apellidop + "','" + apellidom + "','" + correo + "','" + contraseña + "', " + grado + ", " + grupo + ")";

            var con = new Conexion();

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = e.Message;
                // Manejar el error de alguna manera
            }
        }
        public void Agregar_p(string nombre, string apellidop, string apellidom, string correo, string contraseña)
        {
            // Utiliza el nombre correcto de la función de PostgreSQL para insertar un alumno.
            string sql = "CALL InsertarProfesor('" + nombre + "','" + apellidop + "','" + apellidom + "','" + correo + "','" + contraseña + "')";

            var con = new Conexion();

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }


        public void Profesor_admin(string nombre, string apellidop, string apellidom, string correo)
        {
            // Utiliza el nombre correcto de la función de PostgreSQL para insertar un alumno.
            string sql = "CALL InsertarProfesorAdmin('" + nombre + "','" + apellidop + "','" + apellidom + "','" + correo + "')";

            var con = new Conexion();

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }









        public void Baja_p(string nombre, string apellidop, string apellidom, string correo)
        {
            ProfesorDatos alu = new ProfesorDatos();
            List<Profesores> lista = alu.Consultar();


            foreach (Profesores alumnos in lista)
            {

                string Correo_L = alumnos.Correo;
                string Nombre_L = alumnos.Nombre;
                string Paterno = alumnos.Apellidop;
                string Materno = alumnos.Apellidom;


                if (Correo_L == correo && Nombre_L == nombre && Paterno == apellidop && Materno == apellidom)
                {
                    string sql = "CALL EliminarProfesor(" + alumnos.IdProfe + ")";

                    var con = new Conexion();

                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        string error = e.Message;
                    }
                }
            }

        }

        public void Baja_p_admin(string nombre, string apellidop, string apellidom, string correo)
        {
            ProfesoresVerif alu = new ProfesoresVerif();
            List<ProfesoresAdminModel> lista = alu.Consultar();


            foreach (ProfesoresAdminModel alumnos in lista)
            {

                string Correo_L = alumnos.Correo;
                string Nombre_L = alumnos.Nombre;
                string Paterno = alumnos.Apellidop;
                string Materno = alumnos.Apellidom;


                if (Correo_L == correo && Nombre_L == nombre && Paterno == apellidop && Materno == apellidom)
                {
                    string sql = "CALL EliminarProfesorAdmin(" + alumnos.IdProfe + ")";

                    var con = new Conexion();

                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        string error = e.Message;
                    }
                }
            }

        }

        public void Baja_a(string nombre, string apellidop, string apellidom, string correo, int Grupo)
        {
            AlumnoDatos alu = new AlumnoDatos();
            List<Alumnos> lista = alu.Consultar();


            foreach (Alumnos alumnos in lista)
            {
                
                string Correo_L = alumnos.Correo;
                string Nombre_L = alumnos.Nombre;
                string Paterno = alumnos.Apellidop;
                string Materno = alumnos.Apellidom;
                int grupo_L = alumnos.Grupo;
      

                if (Correo_L == correo && Nombre_L == nombre && Paterno==apellidop && Materno==apellidom && grupo_L==Grupo)
                {
                    string sql = "CALL EliminarAlumno("+alumnos.IdAlumno+")";

                    var con = new Conexion();

                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        string error = e.Message;
                    }
                }
            }
            
        }




        public void Alta_g(string nombre, string apellidop, string apellidom, int Grupo)
        {
            ProfesorDatos alu = new ProfesorDatos();
            List<Profesores> lista = alu.Consultar();


            foreach (Profesores alumnos in lista)
            {
                string Nombre_L = alumnos.Nombre;
                string Paterno = alumnos.Apellidop;
                string Materno = alumnos.Apellidom;


                if (Nombre_L == nombre && Paterno == apellidop && Materno == apellidom)
                {
                    string sql = "CALL InsertarGrupo(" + Grupo + "," + alumnos.IdProfe + ")";

                    var con = new Conexion();

                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        string error = e.Message;
                    }
                }
            }

        }

        public void Baja_g(int Grupo)
        {
            string sql = "CALL EliminarGrupo("+Grupo+")";

            var con = new Conexion();

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con.AbrirConexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }
    }
}

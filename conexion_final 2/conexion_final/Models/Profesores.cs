using System;
namespace conexion_final.Models
{
	public class Profesores
	{
		public Profesores()
		{
		}
        public int IdProfe { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
    }
}


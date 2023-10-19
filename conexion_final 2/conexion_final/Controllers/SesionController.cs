using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using conexion_final.Models;
using conexion_final.Datos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace conexion_final.Controllers
{
    public class SesionController : Controller
    {
        AdminDatos oAdminDatos = new AdminDatos();
        ProfesorDatos oProfesorDatos = new ProfesorDatos();
        AlumnoDatos oAlumnoDatos = new AlumnoDatos();

        [HttpPost]
        public ActionResult ProcesarFormulario(IFormCollection form)
        {
            string usuario_c = form["usuario"];
            string contraseña_c = form["contraseña"];

            List<AdminModel> oLista = oAdminDatos.Consultar();
            List<Alumnos> al = oAlumnoDatos.Consultar();
            List<Profesores> prof = oProfesorDatos.Consultar();

            foreach (AdminModel admin in oLista)
            {
                // Accede a las propiedades del objeto AdminModel
                string correo = admin.correo;
                string contraseña = admin.contraseña;

                if (usuario_c == correo && contraseña_c == contraseña)
                {
                    return View("V_admin"); // Redirige a la vista "V_admin"
                }
            }


            foreach (Alumnos admin in al)
            {
                // Accede a las propiedades del objeto AdminModel
                string correo = admin.Correo;
                string contraseña = admin.Contraseña;

                if (usuario_c == correo && contraseña_c == contraseña)
                {
                    return View("V_alu"); // Redirige a la vista "V_alu"
                }
            }


            foreach (Profesores admin in prof)
            {
                // Accede a las propiedades del objeto AdminModel
                string correo = admin.Correo;
                string contraseña = admin.Contraseña;

                if (usuario_c == correo && contraseña_c == contraseña)
                {
                    return View("V_profe"); 
                }
            }

            return View("Error"); // No es necesario, ya que las redirecciones deben ocurrir antes de llegar aquí.
        }



    }
}


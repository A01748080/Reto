using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using conexion_final.Datos;
using conexion_final.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace conexion_final.Controllers
{
    public class ContDatosController : Controller
    {
         Manipulate altaDatos = new Manipulate();

        [HttpPost]
        public ActionResult AltaBuena(IFormCollection form)
        {
            string nombre = form["Nombre"];
            string apellidop = form["AP"];
            string apellidom = form["AM"];
            string correo = form["Correo"];
            string contraseña = form["contraseña"];
            string GradoS = form["Grado"];
            string GrupoS = form["Grupo"];

            
            int Grado = int.Parse(GradoS);
            int Grupo = int.Parse(GrupoS);

           altaDatos.Agregar(nombre, apellidop, apellidom, correo, contraseña, Grado, Grupo);
           return View("Alta_e");
           
        }

        [HttpPost]
        public ActionResult AltaBuena_p(IFormCollection form)
        {
            string nombre = form["Nombre"];
            string apellidop = form["AP"];
            string apellidom = form["AM"];
            string correo = form["Correo"];

            altaDatos.Profesor_admin(nombre, apellidop, apellidom, correo);
            return View("Alta_e");

        }

        [HttpPost]
        public ActionResult Baja_a(IFormCollection form)
        {
            string nombre = form["Nombre"];
            string apellidop = form["AP"];
            string apellidom = form["AM"];
            string correo = form["Correo"];
            string GrupoS = form["Grupo"];

            int Grupo = int.Parse(GrupoS);
            altaDatos.Baja_a(nombre, apellidop, apellidom, correo, Grupo);
            return View("Baja_e");

        }


        [HttpPost]
        public ActionResult Baja_p(IFormCollection form)
        {
            string nombre = form["Nombre"];
            string apellidop = form["AP"];
            string apellidom = form["AM"];
            string correo = form["Correo"];

            altaDatos.Baja_p(nombre, apellidop, apellidom, correo);
            altaDatos.Baja_p_admin(nombre, apellidop, apellidom, correo);
            return View("Baja_e");

        }

        [HttpPost]
        public ActionResult Alta_g(IFormCollection form)
        {
            string GrupoS = form["Grupo"];
            string nombre = form["nombre"];
            string apellidop = form["AP"];
            string apellidom = form["AM"];

            int Grupo = int.Parse(GrupoS);

            altaDatos.Alta_g(nombre, apellidop, apellidom,Grupo);
            return View("Alta_g");

        }

        [HttpPost]
        public ActionResult Baja_g(IFormCollection form)
        {
            string GrupoS = form["Grupo"];
            int Grupo = int.Parse(GrupoS);

            altaDatos.Baja_g(Grupo);
            return View("Baja_g");

        }

        [HttpPost]
        public ActionResult Registro_a(IFormCollection form)
        {
            string nombre = form["Nombre"];
            string apellidop = form["AP"];
            string apellidom = form["AM"];
            string correo = form["Correo"];
            string contraseña = form["contraseña"];
            string GradoS = form["Grado"];
            string GrupoS = form["Grupo"];
            int Grado = int.Parse(GradoS);
            int Grupo = int.Parse(GrupoS);

            altaDatos.Agregar(nombre, apellidop, apellidom, correo, contraseña, Grado, Grupo);
            return View("Registro_u");

        }

        [HttpPost]
        public ActionResult Registro_p(IFormCollection form)
        {
            ProfesoresVerif prof = new ProfesoresVerif();
            List<ProfesoresAdminModel> lista = prof.Consultar();
            string nombre = form["Nombre"];
            string apellidop = form["AP"];
            string apellidom = form["AM"];
            string correo = form["Correo"];
            string contraseña = form["contraseña"];

            foreach (ProfesoresAdminModel alumnos in lista)
            {

                string Correo_L = alumnos.Correo;
                string Nombre_L = alumnos.Nombre;
                string Paterno = alumnos.Apellidop;
                string Materno = alumnos.Apellidom;

                if(Correo_L==correo && Nombre_L==nombre && Paterno==apellidop && Materno == apellidom)
                {
                    altaDatos.Agregar_p(nombre, apellidop, apellidom, correo, contraseña);
                    return View("Registro_u");
                }
            }
            return View("Registro_f");

        }

    }
}


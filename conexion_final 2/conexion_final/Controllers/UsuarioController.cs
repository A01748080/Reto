using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using conexion_final.Models;
using conexion_final.Datos;

namespace WebLogin.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel oUsuario = new UsuarioModel();
        UsuarioDatos oUsuarioDatos = new UsuarioDatos();

        public ActionResult listar()
        {
            var oLista = oUsuarioDatos.Consultar();
            return View(oLista);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace conexion_final.Controllers
{
    public class CalificacionesController : Controller
    {
        public IActionResult Calificaciones_a()
        {
            return View();
        }
    }

}



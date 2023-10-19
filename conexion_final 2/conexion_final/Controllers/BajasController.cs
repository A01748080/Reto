using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace conexion_final.Controllers
{
    public class BajasController : Controller
    {
        // GET: /<controller>/
        public IActionResult Baja_alumno()
        {
            return View();
        }

        public IActionResult Baja_profesor()
        {
            return View();
        }
        public IActionResult Baja_gr()
        {
            return View();
        }
    }
}


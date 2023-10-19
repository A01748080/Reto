using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace conexion_final.Controllers
{
    public class RpController : Controller
    {
        // GET: /<controller>/
        public IActionResult Ra()
        {
            return View();
        }
        public IActionResult R_p()
        {
            return View();
        }
    }
}


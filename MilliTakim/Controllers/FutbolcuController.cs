using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Controllers
{
    public class FutbolcuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Controllers
{
    public class MyUser : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rolesDemoSSD.Data;
using rolesDemoSSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Controllers
{
    public class ProductController : Controller
    {
        readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
           
            return View(_context.Products);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rolesDemoSSD.Data;
using rolesDemoSSD.Models;
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

        public object Session { get; private set; }

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string searchString, string filterList)
        {

            ViewData["CurrentFilter"] = searchString;
            ViewData["FilteredDropDown"] = filterList;

            var products = from s in _context.Products
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.ToLower().Contains(searchString));
            }
            if (!String.IsNullOrEmpty(filterList))
            {
                products = products.Where(s => s.Category.Contains(filterList));
            }

            return View(await products.AsNoTracking().ToListAsync());
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(ProductVM pVM)
        //{
        //    ProductRepo proRepo = new ProductRepo(_context);
        //    UserRepo userRepo = new UserRepo(_context);

        //    if (ModelState.IsValid)
        //    {
        //        pVM.UserID = userRepo.GetUserId(User.Identity.Name);
        //        proRepo.Add(pVM);
        //        return RedirectToAction("Index", "Product");
        //    }
        //    else
        //    {
        //        return View(pVM);
        //    }
        //}


        public ActionResult Details(int productID)
        {
            Console.WriteLine(productID);
            ProductRepo productRepo = new ProductRepo(_context);
            ProductVM productVM = productRepo.Get(productID);
            return View(productVM);
        }

        public ActionResult AddToCart(Products pro)
        {
            Cart c = new Cart();
            c.AddedOn = DateTime.Now;
            c.UserID = _context.MyUser.Where(m => m.UserName == User.Identity.Name).FirstOrDefault().UserID;
            c.ProductID = pro.ProductID;
            c.UpdatedOn = DateTime.Now;

            _context.Carts.Add(c);
            _context.SaveChanges();

            TempData["ProductAddedToCart"] = "Product added to cart successfully";
            //if (Session["cart"] == null)
            //{
            //    List<Products> li = new List<Products>();

            //    li.Add(pro);
            //    Session["cart"] = li;
            //    ViewBag.cart = li.Count();
            //    Session["count"] = 1;
            //}
            //else
            //{
            //    List<Products> li = (List<Products>)Session["cart"];
            //    li.Add(pro);
            //    Session["cart"] = li;
            //    ViewBag.cart = li.Count();
            //    Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            //}
            return RedirectToAction("Index", "Product");

        }
    }
}

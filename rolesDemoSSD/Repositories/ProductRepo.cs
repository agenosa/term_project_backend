using rolesDemoSSD.Data;
using rolesDemoSSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Repositories
{
    public class ProductRepo
    {
        ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        // Get all users in the database.
        public IEnumerable<Products> All()
        {
            var products = _context.Products.Select(p => new Products()
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Photo = p.Photo,
                Category = p.Category,
                Price = p.Price

            });
            return products;
        }

        public ProductVM Get(int productID)
        {
            var product = _context.Products.Select(p => new ProductVM()
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Photo = p.Photo,
                Description = p.Description,
                Category = p.Category,
                Price = p.Price

            }).Where(p => p.ProductID == productID)
            .FirstOrDefault();

            return product;

        }

        //public int Add(ProductVM pVM)
        //{

        //    Products product = new Products()
        //    {
        //        ProductID = pVM.ProductID,
        //        ProductName = pVM.ProductName,
        //        Category = pVM.Category,
        //        Price = pVM.Price,
        //        Photo = pVM.Photo,
        //        Description = pVM.Description,
        //        LocationTag = pVM.LocationTag,
        //        UserID = pVM.UserID,
        //        InvoiceID = pVM.InvoiceID
        //    };

        //    _context.Products.Add(product);
        //    _context.SaveChanges();

        //    return true;
        //}
    }
}

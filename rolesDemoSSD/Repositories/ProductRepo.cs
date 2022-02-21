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
        public IEnumerable<ProductVM> All()
        {
            var products = _context.Products.Select(p => new ProductVM()
            {
                ProductID = p.ProductID
            });
            return products;
        }
        
        //public ProductVM Get (int productID)
        //{
        //    var product = _context.Products.Select(p => new ProductVM())

        //    return product;

        //}
    }
}

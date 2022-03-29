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
        
        public int Add(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();

            return products.ProductID;
        }
    }
}

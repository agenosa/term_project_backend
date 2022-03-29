using rolesDemoSSD.Data;
using rolesDemoSSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Repositories
{
    public class ProductUserRepo
    {
        ApplicationDbContext _context;

        public ProductUserRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        // Believe we need to add ProductUser table to get this working
        //public bool Add(ProductUser pu)
        //{
        //    UserRepo userRepo = new UserRepo(_context);
        //    int UserId = userRepo.GetUserId(pu.Email);

        //    ProductRepo productRepo = new ProductRepo(_context);
        //    Products product = new Products { ProductName = pu.}
        //}
    }
}

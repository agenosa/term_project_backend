using rolesDemoSSD.Data;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class ProductsModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; } // will have to figure out better variable type for this??
        public string Description { get; set; }
        public string LocationTag { get; set; }
    }
}

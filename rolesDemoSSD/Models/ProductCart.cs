using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class ProductCart
    {
        [Key, Column(Order = 0)]
        public int CartID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        public int Qty { get; set; }

        // Navigation properties.
        // Parents.
        public virtual Products Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}

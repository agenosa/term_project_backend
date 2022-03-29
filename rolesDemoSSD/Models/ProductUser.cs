using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class ProductUser
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }

        // Navigation Properties
        // Parents
        public virtual Products Products { get; set; }
        public virtual MyUser MyUser { get; set; }
    }
}

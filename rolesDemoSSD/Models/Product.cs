using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Category { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; } // ^^^^^will have to figure out better variable type for this??
        [Required]
        public string Description { get; set; }
        [Required]
        public string LocationTag { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int InvoiceID { get; set; }

        public virtual User User { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}

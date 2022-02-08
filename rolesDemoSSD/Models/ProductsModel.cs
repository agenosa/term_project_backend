using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class ProductsModel
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Photo { get; set; } // will have to figure out better variable type for this??
        [Required]
        public string Description { get; set; }
        public string LocationTag { get; set; }
        [Key]
        [ForeignKey("Invoices")]
        public string InvoiceID { get; set; }
        [Key]
        [ForeignKey("Users")]
        public string UserID { get; set; }
    }
}

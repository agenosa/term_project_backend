using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class Products
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
        public string Photo { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string LocationTag { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int InvoiceID { get; set; }
        public int CartID { get; set; }

        public virtual ICollection<ProductCart> ProductCart { get; set; }
        public virtual MyUser MyUser { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}

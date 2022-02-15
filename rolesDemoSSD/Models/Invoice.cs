using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal InvoiceTotal { get; set; }
        [Required]
        public string PaymentMethod { get; set; } // need to make dropdown list
        [Required]
        public int UserID { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual MyUser User { get; set; }
    }
}

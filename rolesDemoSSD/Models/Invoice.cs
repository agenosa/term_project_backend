using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Required]
        public decimal InvoiceTotal { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

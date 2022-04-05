using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace rolesDemoSSD.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime UpdatedOn { get; set; }
        //[Required]
        //[DataType(DataType.Currency)] 
        //public decimal InvoiceTotal { get; set; }

        public virtual ICollection<ProductCart> ProductCart { get; set; }
        public virtual MyUser MyUser { get; set; }
    }
}
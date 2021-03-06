using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class MyUser
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber,ErrorMessage = "Incorrect Format")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } // ^^^^May neeed to change datatype
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        [Range(6, 6, ErrorMessage = "Please Enter correct format. Eg.C5X35B")]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool isAdmin { get; set; }

        public int CartID { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual Cart Cart { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        [Required]
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

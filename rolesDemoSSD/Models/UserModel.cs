using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}

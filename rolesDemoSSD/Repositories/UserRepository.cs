using rolesDemoSSD.Data;
using rolesDemoSSD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolesDemoSSD.Repositories
{
    public class UserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        // Get all users in the database.
        public IEnumerable<UserVM> All()
        {
            var users = _context.Users.Select(u => new UserVM()
            {
                Email = u.Email
            });
            return users;
        }

        public int GetUserId(string email)
        {
            int userID = _context.MyUser
                .Where(u => u.Email == email)
                .Select(u => u.UserID).FirstOrDefault();

            return userID;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot_App.Data;
using YellowCarrot_App.Models;

namespace YellowCarrot_App.Services
{
    internal class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /*
       public User? GetUser(int id)
       {
           List<User> users = new()
           {
               new User()
               {
                   UserId = 1,
                   UserNamn = "user",
                   Password= "password"
               },

               new User()
               {
                   UserId = 2,
                   UserNamn = "admin",
                   Password= "password"
               }

           };

           User? currentUser = users.FirstOrDefault(c => c.UserId == id);

           return currentUser;
       }
*/
        /*  public void AddDefaultUsers()
          {

              _context.User.Add(new User()
              {
                  UserNamn = "user",
                  Password = "password"
              });

              _context.SaveChanges();
         } */

        public List<User> GetUsers()
        {
            return _context.User.ToList();
        }

        public User? GetUser(string userName)
        {
           return _context.User.FirstOrDefault(c => c.UserNamn == userName);
        }

        public void AddUser(User userToAdd)
        {
            _context.User.Add(userToAdd);
        }

        public void RemoveUser(User userToRemove)
        {
            _context.User.Remove(userToRemove);
        }

        public void VerifyUser(User userToUpdate) 
        {
        
        }
        
    }
}

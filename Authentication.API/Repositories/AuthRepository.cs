using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.API.DataAccess;
using Authentication.API.Models;

namespace Authentication.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IAuthenticationContext context;
        public AuthRepository(IAuthenticationContext dbContext)
        {
            context = dbContext;
        }
        
        public User FindUserById(string userName)
        {
            return context.Users.Where(u => u.UserName == userName).FirstOrDefault();
        }

        public User LoginUser(string userName, string password)
        {
            return context.Users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
        }

        public bool RegisterUser(User user)
        {
            var checkUser = FindUserById(user.UserName);
            if (checkUser != null)
            {
                return false;
            }

            context.Users.Add(user);
            int result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

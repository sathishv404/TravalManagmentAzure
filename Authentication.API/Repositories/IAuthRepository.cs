using Authentication.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.API.Repositories
{
    public interface IAuthRepository
    {
        bool RegisterUser(User user);
        User LoginUser(string userId, string password);
        User FindUserById(string userId);
    }
}

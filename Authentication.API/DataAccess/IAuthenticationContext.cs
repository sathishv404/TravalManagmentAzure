using Authentication.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.API.DataAccess
{
    public interface IAuthenticationContext
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}

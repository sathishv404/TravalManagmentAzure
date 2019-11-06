using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.DataAccess
{

    public class AuthenticationContext : DbContext, IAuthenticationContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //User
            builder.Entity<User>().HasKey(m => m.UserId);
            builder.Entity<User>().Property(u => u.UserName).IsRequired();
            builder.Entity<User>().Property(u => u.Password).IsRequired();
            builder.Entity<User>().Property(u => u.FullName).IsRequired();
            builder.Entity<User>().Property(u => u.Contact).IsRequired();
            builder.Entity<User>().Property(u => u.Role).IsRequired();
            builder.Entity<User>().ToTable("Users");
            base.OnModelCreating(builder);

        }



    }
}

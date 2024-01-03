using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Seeding
{
    public static class UserSeeding
    {
        public static async Task addUserAsync(UserManager<User> _userManager)
        {
            if (!await _userManager.Users.AnyAsync())
            {
                var user = new User
                {
                    FullName = "admin",
                    UserName = "admin",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                   
                    
                };

                await _userManager.CreateAsync(user,"admin");
                await _userManager.AddToRoleAsync(user, "Admin");
               await _userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using ClientAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClientAPI.Bootstrapper {
    public class RoleSeeder {
        private readonly IServiceProvider _sProvider;
        public RoleSeeder (IServiceProvider sProvider) {

            _sProvider = sProvider;
        }
        public async Task SeedRoles () {

            var roleManager = _sProvider.GetRequiredService<RoleManager<IdentityRole>> ();

            //this is ready if there will be default user
            var userManager = _sProvider.GetRequiredService<UserManager<ApplicationUser>> ();
           
            string[] roleNames = { "Admin", "User", "Member","Manager" };

            foreach (var roleName in roleNames) {

                if (!(await roleManager.RoleExistsAsync (roleName)))
                    await roleManager.CreateAsync (new IdentityRole { Name = roleName });

            }
          
        }

    }
}
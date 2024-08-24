using FastFood.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FastFood.Repository
{
    public class DbInitializer : IDbInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppliDbContext _context;

        public DbInitializer(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, AppliDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public void Initialize()
        {
            try                        //its checkes existing of maneger or admin or user if existing member then it privient the registration
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            
            }

            if (_context.Roles.Any(x => x.Name == "Admin")) return;
            _roleManager.CreateAsync(new IdentityRole("Manager")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();
            var user = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Admin",
                City = "Xyz",
                PostalCode = "333333"
            };
            _userManager.CreateAsync(user,"Admin@123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

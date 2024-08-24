using FastFood.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FastFood.Repository
{
    public class AppliDbContext: IdentityDbContext
    {
        public AppliDbContext(DbContextOptions<AppliDbContext>options):base(options)

        {
            
        }
       public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orderheader> Orderheaders { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

    }
}

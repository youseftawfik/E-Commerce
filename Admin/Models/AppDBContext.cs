using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Admin.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Admin.Models
{
    public class AppDBContext : IdentityDbContext<IdentityUser>
    {
        
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Brands>().HasOne(s => s.subCategory).WithMany(s => s.Brands).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductImages> ProductsImage { get; set; }
        public DbSet<ProdectDetails> ProductsInfo { get; set; }

    }
}

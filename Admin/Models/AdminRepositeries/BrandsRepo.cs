using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Admin.Models.AdminRepositeries
{
    public class BrandsRepo : IAdmin<Brands>
    {
        private readonly AppDBContext context;
        public BrandsRepo(AppDBContext appDB)
        {
            context = appDB;
        }

        public void ADD(Brands brands)
        {
            context.Brands.Add(brands);
            context.SaveChanges();
        }

        public void Delete(int ID)
        {
            var brand = context.Brands.FirstOrDefault(b => b.ID == ID);
            context.Brands.Remove(brand);
            context.SaveChanges();
        }

        public Brands Find(int ID)
        {
            var brand = context.Brands.Include(s=>s.subCategory).FirstOrDefault(b => b.ID == ID);
            return brand;
        }

        public IList<Brands> list()
        {
            return context.Brands.Include(s => s.subCategory).ToList();
        }

        public void Update(int ID, Brands brands)
        {
            var brand = context.Brands.FirstOrDefault(c => c.ID == brands.ID);
            brand.Brand_Name = brands.Brand_Name;
            brand.Brand_Image = brands.Brand_Image;
            brand.subCategory = brands.subCategory;
            brand.Status = brands.Status;
            context.SaveChanges(); 
        }
    }
}

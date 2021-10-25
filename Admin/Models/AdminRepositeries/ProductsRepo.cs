using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Admin.Models.AdminRepositeries
{
    public class ProductsRepo : IAdmin<Products>
    {
        private readonly AppDBContext context;

        public ProductsRepo(AppDBContext appDB)
        {
            context = appDB;
        }
        public void ADD(Products NewProduct)
        {
            context.Products.Add(NewProduct);
            context.SaveChanges();
        }

        public void Delete(int ID)
        {
            var product = context.Products.FirstOrDefault(b => b.ID == ID);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public Products Find(int ID)
        {
            var pro = context.Products.Include(s => s.SubCategory).FirstOrDefault(s => s.ID == ID);
            return pro;
        }

        public IList<Products> list()
        {
            return context.Products.Include(s => s.SubCategory).Include(b=>b.Brands).ToList();
        }

        public void Update(int ID, Products NewProduct)
        {
            var product = context.Products.FirstOrDefault(c => c.ID == NewProduct.ID);
            product.Product_Name = NewProduct.Product_Name;
            product.Product_Image = NewProduct.Product_Image;
            product.SubCategory = NewProduct.SubCategory;
            product.Brands = NewProduct.Brands;
            context.SaveChanges();
        }
    }
}

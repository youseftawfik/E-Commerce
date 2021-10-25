using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models.UserRepositeries
{
    public class CategoryRepo : IAdmin<Category>
    {
        private AppDBContext context;
        public CategoryRepo(AppDBContext appDB)
        {
            context = appDB;
        }

        public void ADD(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Delete(int ID)
        {
            var category = context.Categories.FirstOrDefault(c => c.ID == ID);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public Category Find(int ID)
        {
            var category = context.Categories.FirstOrDefault(c => c.ID == ID);
            return category;
        }

        public IList<Category> list()
        {
           return context.Categories.ToList();
        }

        public void Update(int ID, Category NewCategory)
        {
            var category = context.Categories.FirstOrDefault(c => c.ID == NewCategory.ID);
            category.Category_Name = NewCategory.Category_Name;
            category.Category_Image = NewCategory.Category_Image;
            category.Status = NewCategory.Status;
            context.SaveChanges();
        }
    }
}

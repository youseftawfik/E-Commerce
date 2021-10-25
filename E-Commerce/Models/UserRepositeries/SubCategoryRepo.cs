using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models.UserRepositeries
{
    public class SubCategoryRepo : IAdmin<SubCategory>
    {
        private AppDBContext context;

        public SubCategoryRepo(AppDBContext appDB)
        {
            context = appDB;
        }

        public void ADD(SubCategory subCategory )
        {
            context.SubCategories.Add(subCategory);
            context.SaveChanges();
        }

        public void Delete(int ID)
        {
            var sub = context.SubCategories.FirstOrDefault(s => s.ID == ID);
            context.SubCategories.Remove(sub);
            context.SaveChanges();
        }

        public SubCategory Find(int ID)
        {
            var sub = context.SubCategories.Include(c => c.Categories).FirstOrDefault(s => s.ID == ID);
            return sub;
        }

        public IList<SubCategory> list()
        {
            return context.SubCategories.Include(c => c.Categories).ToList();
        }

        public void Update(int ID, SubCategory subCategory)
        {
            var sub = context.SubCategories.FirstOrDefault(c => c.ID == subCategory.ID);
            sub.SubCategory_Name = subCategory.SubCategory_Name;
            sub.SubCategory_Image = subCategory.SubCategory_Image;
            sub.Categories = subCategory.Categories;
            sub.Status = subCategory.Status;
            context.SaveChanges();
        }
    }
}

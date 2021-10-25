using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Models;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.ViewModel
{
    public class Brands_SubViewModel
    {
        public int ID { get; set; }
        public string Brand_Name { get; set; }
        public string Brand_Image { get; set; }
        public bool Status { get; set; }
        public int SubCategoryID { get; set; }
        public List<SubCategory> SubCategory { get; set; }
        public int CategoryID { get; set; }
        public List<Category> Category { get; set; }
        //public IFormFile File { get; set; }

    }
}

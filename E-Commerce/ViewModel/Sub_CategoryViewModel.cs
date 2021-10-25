using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Models;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.ViewModel
{
    public class Sub_CategoryViewModel
    {
        public int ID { get; set; }
        public string SubCategory_Name { get; set; }
        public string SubCategory_Image { get; set; }
        public bool Status { get; set; }
        public int Category_ID { get; set; }
        public List<Category> Categories { get; set; }
        public IFormFile File { get; set; }
    }
}

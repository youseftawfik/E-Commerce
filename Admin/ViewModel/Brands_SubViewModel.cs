using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models;
using Microsoft.AspNetCore.Http;

namespace Admin.ViewModel
{
    public class Brands_SubViewModel
    {
        public int ID { get; set; }
        public string Brand_Name { get; set; }
        public string Brand_Image { get; set; }
        public bool Status { get; set; }
        public int subCategoryID { get; set; }
        public List<SubCategory> SubCategory { get; set; }
        public IFormFile File { get; set; }

    }
}

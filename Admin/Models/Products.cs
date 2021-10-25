using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public string Description { get; set; }
        public Brands Brands { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}

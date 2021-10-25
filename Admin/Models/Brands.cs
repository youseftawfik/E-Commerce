using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class Brands
    {
        public int ID { get; set; }
        public string Brand_Name { get; set; }
        public string Brand_Image { get; set; }
        public bool Status { get; set; }
        public SubCategory subCategory { get; set; }
    }
}

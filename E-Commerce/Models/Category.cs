using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Category_Name { get; set; }
        public string Category_Image { get; set; }
        public bool Status { get; set; }
    }
}

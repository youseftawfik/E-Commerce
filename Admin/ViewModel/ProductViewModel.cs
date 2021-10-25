using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models;

namespace Admin.ViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public string Description { get; set; }
        public int BrandID { get; set; }
        public List<Brands> Brands { get; set; }
        public int SubCategoryID { get; set; }
        public List<SubCategory> SubCategory { get; set; }
        public ProductImages Images { get; set; }
        public ProdectDetails Details { get; set; }

    }
}

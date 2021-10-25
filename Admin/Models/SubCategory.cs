using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class SubCategory
    {
        public int ID { get; set; }
        public string SubCategory_Name { get; set; }
        public string SubCategory_Image { get; set; }
        public bool Status { get; set; }
        public Category Categories { get; set; }
        public IList<Brands> Brands { get; } = new List<Brands>();
    }
}

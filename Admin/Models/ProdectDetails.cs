using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class ProdectDetails
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public Products Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Admin.ViewModel
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Category_Name { get; set; }
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public bool Status { get; set; }
        public string Category_Image { get; set; }
    }
}

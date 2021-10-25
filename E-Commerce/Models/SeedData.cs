using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace E_Commerce.Models
{
    public class SeedData
    {
        public static void Pooulated(IApplicationBuilder app)
        {
            AppDBContext con = app.ApplicationServices.GetRequiredService<AppDBContext>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Models;
using E_Commerce.Models.UserRepositeries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdmin<Brands> brandrepo;

        public HomeController(IAdmin<Brands> brandrepo)
        {
            this.brandrepo = brandrepo;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            try
            {
                var brand = brandrepo.list();
                return View(brand);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Products 
        //public ActionResult Electronics()
        //{
        //    try
        //    {
        //        var brand = brandrepo.list();
        //        return View(brand);
        //    }
        //    catch (Exception)
        //    {
        //        return View();
        //    }
        //}
    }
}

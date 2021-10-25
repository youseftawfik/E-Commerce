using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models;
using Admin.Models.AdminRepositeries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IAdmin<Products> productrepo;
        private readonly IAdmin<Brands> brandrepo;
        private readonly IAdmin<SubCategory> subrepo;
        private readonly IHostingEnvironment hosting;

        public ProductsController(IAdmin<Products> productrepo, IAdmin<Brands> brandrepo, IAdmin<SubCategory> subrepo, IHostingEnvironment hosting)
        {
            this.productrepo = productrepo;
            this.brandrepo = brandrepo;
            this.subrepo = subrepo;
            this.hosting = hosting;
        }
        // GET: ProductsController
        public ActionResult Index()
        {
            try
            {
                var product = productrepo.list();
                return View(product);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

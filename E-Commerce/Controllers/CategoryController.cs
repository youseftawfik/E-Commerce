using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using E_Commerce.Models.UserRepositeries;

namespace E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IAdmin<Category> categoryrepo;
        private readonly IHostingEnvironment hosting;

        public CategoryController(IAdmin<Category> categoryrepo, IHostingEnvironment hosting)
        {
            this.categoryrepo = categoryrepo;
            this.hosting = hosting;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = categoryrepo.list();
            return View(categories);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = string.Empty;
                    if (model.File != null)
                    {
                        string images = Path.Combine(hosting.WebRootPath, "uploads");
                        fileName = model.File.FileName;
                        string fullPath = Path.Combine(images, fileName);
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                    Category category = new Category
                    {
                        Category_Name = model.Category_Name,
                        Category_Image = fileName,
                        Status = model.Status
                    };
                    categoryrepo.ADD(category);
                    ViewBag.Success = "Category is Created Successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    //ViewBag.Message = "Category isn't Created.";
                    return View();
                }
            }
            ModelState.AddModelError("", "You Have To Fill All Required Fields !!!");
            return View();
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = categoryrepo.Find(id);
            var ViewModel = new CategoryViewModel
            {
                Category_Name = category.Category_Name,
                Category_Image = category.Category_Image,
                Status = category.Status
            };
            return View(ViewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryViewModel model)
        {
            try
            {
                string fileName = string.Empty;
                if (model.File != null)
                {
                    string images = Path.Combine(hosting.WebRootPath, "uploads");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(images, fileName);

                    string oldfile = categoryrepo.Find(model.ID).Category_Image;

                    if (oldfile == null)
                    {
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    else
                    {
                        string fulloldpath = Path.Combine(images, oldfile);

                        if (fullPath != fulloldpath)
                        {
                            System.IO.File.Delete(fulloldpath);
                            model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                        }
                    }
                }
                Category category = new Category
                {
                    ID = model.ID,
                    Category_Name = model.Category_Name,
                    Category_Image = fileName,
                    Status = model.Status
                };

                categoryrepo.Update(id, category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(categoryrepo.Find(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                categoryrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Activate(int ID, CategoryViewModel model)
        {
            try
            {
                var category = categoryrepo.Find(ID);
                Category cat = new Category
                {
                    ID = model.ID,
                    Category_Name = category.Category_Name,
                    Category_Image = category.Category_Image,
                    Status = true
                };
                categoryrepo.Update(ID, cat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Deactivate(int ID, CategoryViewModel model)
        {
            try
            {
                var category = categoryrepo.Find(ID);
                Category cat = new Category
                {
                    ID = model.ID,
                    Category_Name = category.Category_Name,
                    Category_Image = category.Category_Image,
                    Status = false
                };
                categoryrepo.Update(ID, cat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

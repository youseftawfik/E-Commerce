using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Models;
using E_Commerce.Models.UserRepositeries;
using E_Commerce.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly IAdmin<SubCategory> subrepo;
        private readonly IHostingEnvironment hosting;
        private readonly IAdmin<Category> catrepo;

        public SubCategoriesController(IAdmin<SubCategory> subrepo, IHostingEnvironment hosting,
                                       IAdmin<Category> catrepo)
        {
            this.subrepo = subrepo;
            this.hosting = hosting;
            this.catrepo = catrepo;
        }
        // GET: SubCategoriesController
        public ActionResult Index()
        {
            try
            {
                var sub = subrepo.list().ToList();
                return View(sub);
            }
            catch
            {
                return View();
            }
        }
        // GET: SubCategoriesController/Create
        public ActionResult Create()
        {
            try
            {
                var model = new Sub_CategoryViewModel
                {
                    Categories = catrepo.list().ToList()
                };
                return View(model);
            }
            catch 
            {
                return View();
            }
        }
        //POST: SubCategoriesController/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create(Sub_CategoryViewModel model)
        {
            try
            {
                string fileName = string.Empty;
                if (model.File != null)
                {
                    string images = Path.Combine(hosting.WebRootPath, "uploads/SubCategory");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(images, fileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                SubCategory subcategory = new SubCategory
                {
                    SubCategory_Name = model.SubCategory_Name,
                    SubCategory_Image = fileName,
                    Categories = catrepo.Find(model.Category_ID),
                    Status = model.Status
                };
                subrepo.ADD(subcategory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: SubCategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var subcategory = subrepo.Find(id);
                var catID = subcategory.Categories == null ? subcategory.Categories.ID = 0 : subcategory.Categories.ID;
                var ViewModel = new Sub_CategoryViewModel
                {
                    SubCategory_Name = subcategory.SubCategory_Name,
                    SubCategory_Image = subcategory.SubCategory_Image,
                    Status = subcategory.Status,
                    Category_ID = catID,
                    Categories = catrepo.list().ToList() 
                };
                return View(ViewModel);
            }
            catch 
            {
                return RedirectToAction(nameof(Index));
            }
        }
        // POST: SubCategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sub_CategoryViewModel model)
        {
            try
            {
                string fileName;
                if (model.File != null)
                {
                    string images = Path.Combine(hosting.WebRootPath, "uploads/SubCategory");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(images, fileName);

                    string oldfile = subrepo.Find(model.ID).SubCategory_Image;

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

                SubCategory Sub = new SubCategory
                {
                    ID = model.ID,
                    SubCategory_Name = model.SubCategory_Name,
                    SubCategory_Image = model.SubCategory_Image,
                    Categories = catrepo.Find(model.Category_ID),
                    Status = model.Status
                };

                subrepo.Update(id, Sub);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: SubCategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(subrepo.Find(id));
        }
        // POST: SubCategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,IFormCollection collection)
        {
            try
            {
                subrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Activate(int ID, Sub_CategoryViewModel model)
        {
            try
            {
                var subcategory = subrepo.Find(ID);
                SubCategory sub = new SubCategory
                {
                    ID = model.ID,
                    SubCategory_Name = subcategory.SubCategory_Name,
                    SubCategory_Image = subcategory.SubCategory_Image,
                    Status = true
                };
                subrepo.Update(ID, sub);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Deactivate(int ID, Sub_CategoryViewModel model)
        {
            try
            {
                var subcategory = subrepo.Find(ID);
                SubCategory sub = new SubCategory
                {
                    ID = model.ID,
                    SubCategory_Name = subcategory.SubCategory_Name,
                    SubCategory_Image = subcategory.SubCategory_Image,
                    Status = false
                };
                subrepo.Update(ID, sub);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

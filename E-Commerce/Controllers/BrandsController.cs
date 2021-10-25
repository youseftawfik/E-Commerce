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
    //public class BrandsController : Controller
    //{
    //    private readonly IAdmin<Brands> brandrepo;
    //    private readonly IAdmin<SubCategory> subrepo;
    //    private readonly IHostingEnvironment hosting;

    //    public BrandsController(IAdmin<Brands> brandrepo, IAdmin<SubCategory> subrepo, IHostingEnvironment hosting)
    //    {
    //        this.brandrepo = brandrepo;
    //        this.subrepo = subrepo;
    //        this.hosting = hosting;
    //    }
    //    // GET: BrandsController
    //    public ActionResult Index()
    //    {
    //        try
    //        {
    //            var brand = brandrepo.list();
    //            return View(brand);
    //        }
    //        catch (Exception)
    //        {
    //            return View();
    //        }

    //    }
    //    // GET: BrandsController/Details/5
    //    public ActionResult Details(int id) => View();
    //    // GET: BrandsController/Create
    //    public ActionResult Create()
    //    {
    //        try
    //        {
    //            var model = new Brands_SubViewModel
    //            {
    //                SubCategory = subrepo.list().ToList()
    //            };
    //            return View(model);
    //        }
    //        catch (Exception)
    //        {
    //            return View();
    //        }

    //    }
    //    // POST: BrandsController/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(Brands_SubViewModel model)
    //    {
    //        try
    //        {
    //            string fileName = string.Empty;
    //            if (model.File != null)
    //            {
    //                string images = Path.Combine(hosting.WebRootPath, "uploads/Brands");
    //                fileName = model.File.FileName;
    //                string fullPath = Path.Combine(images, fileName);
    //                model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
    //            }

    //            Brands brands = new()
    //            {
    //                Brand_Name = model.Brand_Name,
    //                Brand_Image = fileName,
    //                subCategory = subrepo.Find(model.subCategoryID),
    //                Status = model.Status
    //            };
    //            brandrepo.ADD(brands);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //    // GET: BrandsController/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        try
    //        {
    //            var brand = brandrepo.Find(id);
    //            var subcatID = brand.subCategory == null ? brand.subCategory.ID = 0 : brand.subCategory.ID;
    //            var ViewModel = new Brands_SubViewModel
    //            {
    //                Brand_Name = brand.Brand_Name,
    //                Brand_Image = brand.Brand_Image,
    //                Status = brand.Status,
    //                subCategoryID = subcatID,
    //                SubCategory = subrepo.list().ToList()
    //            };
    //            return View(ViewModel);
    //        }
    //        catch
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //    }
    //    // POST: BrandsController/Edit/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(int id, Brands_SubViewModel model)
    //    {
    //        try
    //        {
    //            string fileName = string.Empty;
    //            if (model.File != null)
    //            {
    //                string images = Path.Combine(hosting.WebRootPath, "uploads/Brands");
    //                fileName = model.File.FileName;
    //                string fullPath = Path.Combine(images, fileName);

    //                string oldfile = brandrepo.Find(model.ID).Brand_Image;

    //                if (oldfile == null)
    //                {
    //                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
    //                }
    //                else
    //                {
    //                    string fulloldpath = Path.Combine(images, oldfile);

    //                    if (fullPath != fulloldpath)
    //                    {
    //                        System.IO.File.Delete(fulloldpath);
    //                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
    //                    }
    //                }
    //            }

    //            Brands brand = new()
    //            {
    //                ID = model.ID,
    //                Brand_Name = model.Brand_Name,
    //                Brand_Image = fileName,
    //                subCategory = subrepo.Find(model.subCategoryID),
    //                Status = model.Status
    //            };

    //            brandrepo.Update(id, brand);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //    // GET: BrandsController/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        return View(brandrepo.Find(id));
    //    }
    //    // POST: BrandsController/Delete/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Delete(int id, IFormCollection collection)
    //    {
    //        try
    //        {
    //            brandrepo.Delete(id);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //    public ActionResult Activate(int ID, Brands_SubViewModel model)
    //    {
    //        try
    //        {
    //            var brands = brandrepo.Find(ID);
    //            Brands brand = new()
    //            {
    //                ID = model.ID,
    //                Brand_Name = brands.Brand_Name,
    //                Brand_Image = brands.Brand_Image,
    //                subCategory = brands.subCategory,
    //                Status = true
    //            };
    //            brandrepo.Update(ID, brand);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //    public ActionResult Deactivate(int ID, Brands_SubViewModel model)
    //    {
    //        try
    //        {
    //            var brands = brandrepo.Find(ID);
    //            Brands brand = new()
    //            {
    //                ID = model.ID,
    //                Brand_Name = brands.Brand_Name,
    //                Brand_Image = brands.Brand_Image,
    //                subCategory = brands.subCategory,
    //                Status = false
    //            };
    //            brandrepo.Update(ID, brand);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //}
}


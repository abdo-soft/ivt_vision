using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using ivt_ass.Models;
using System.IO;
using Core.Interfaces;

namespace ivt_ass.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IUnitOfWork<Category> Categ { get; }

        public IHostingEnvironment Hosting { get; }

        public CategoryController(IUnitOfWork<Category> categ, IHostingEnvironment hosting)
        {
            Categ = categ;
            Hosting = hosting;
        }

        // GET: Admin/Category
        public  IActionResult Index()
        {
            return View(Categ.Entity.GetAll());
        }

        // GET: Admin/Category/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = Categ.Entity.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string uploads = Path.Combine(Hosting.WebRootPath, @"assets\img");
                    string fullPath = Path.Combine(uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                Category cate = new Category
                {
                    Cname = model.Cname,
                    Description = model.Description,
                    ImageUrl = model.File.FileName

                };
                Categ.Entity.Insert(cate);
                Categ.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Admin/Category/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var catitem = Categ.Entity.GetById(id);
            if (catitem== null)
            {
                return NotFound();
            }

            CategoryModel catModel = new CategoryModel
            {
                Id = catitem.id,
                Description = catitem.Description,
                ImageUrl = catitem.ImageUrl,
                Cname = catitem.Cname
            };

            return View(catitem);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, CategoryModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.File != null)
                    {
                        string uploads = Path.Combine(Hosting.WebRootPath, @"assets\img");
                        string fullPath = Path.Combine(uploads, model.File.FileName);
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    Category cate = new Category
                    {
                        Cname = model.Cname,
                        Description = model.Description,
                        ImageUrl = model.File.FileName

                    };
                    Categ.Entity.Update(cate);
                    Categ.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Admin/Category/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = Categ.Entity.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Categ.Entity.Delete(id);
            Categ.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(Guid id)
        {
            return Categ.Entity.GetAll().Any(e => e.id == id);
        }

        //login page
      
    }
}

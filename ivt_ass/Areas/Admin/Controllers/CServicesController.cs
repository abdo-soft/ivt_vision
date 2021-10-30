using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure;

namespace ivt_ass.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CServicesController : Controller
    {
        private readonly DataC _context;

        public CServicesController(DataC context)
        {
            _context = context;
        }

        // GET: Admin/CServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.CServices.ToListAsync());
        }

        // GET: Admin/CServices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cServices = await _context.CServices
                .FirstOrDefaultAsync(m => m.id == id);
            if (cServices == null)
            {
                return NotFound();
            }

            return View(cServices);
        }

        // GET: Admin/CServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sname,Price,Duration,ImageUrl,id")] CServices cServices)
        {
            if (ModelState.IsValid)
            {
                cServices.id = Guid.NewGuid();
                _context.Add(cServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cServices);
        }

        // GET: Admin/CServices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cServices = await _context.CServices.FindAsync(id);
            if (cServices == null)
            {
                return NotFound();
            }
            return View(cServices);
        }

        // POST: Admin/CServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Sname,Price,Duration,ImageUrl,id")] CServices cServices)
        {
            if (id != cServices.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CServicesExists(cServices.id))
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
            return View(cServices);
        }

        // GET: Admin/CServices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cServices = await _context.CServices
                .FirstOrDefaultAsync(m => m.id == id);
            if (cServices == null)
            {
                return NotFound();
            }

            return View(cServices);
        }

        // POST: Admin/CServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cServices = await _context.CServices.FindAsync(id);
            _context.CServices.Remove(cServices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CServicesExists(Guid id)
        {
            return _context.CServices.Any(e => e.id == id);
        }
    }
}

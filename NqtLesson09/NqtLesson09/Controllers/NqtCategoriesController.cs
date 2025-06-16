using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NqtLesson09.Models;

namespace NqtLesson09.Controllers
{
    public class NqtCategoriesController : Controller
    {
        private readonly NqtBookStoreBookStoreContext _context;

        public NqtCategoriesController(NqtBookStoreBookStoreContext context)
        {
            _context = context;
        }

        // GET: NqtCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.NqtCategories.ToListAsync());
        }

        // GET: NqtCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtCategory = await _context.NqtCategories
                .FirstOrDefaultAsync(m => m.NqtCategoryId == id);
            if (nqtCategory == null)
            {
                return NotFound();
            }

            return View(nqtCategory);
        }

        // GET: NqtCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NqtCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NqtCategoryId,NqtCategoryName")] NqtCategory nqtCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nqtCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nqtCategory);
        }

        // GET: NqtCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtCategory = await _context.NqtCategories.FindAsync(id);
            if (nqtCategory == null)
            {
                return NotFound();
            }
            return View(nqtCategory);
        }

        // POST: NqtCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NqtCategoryId,NqtCategoryName")] NqtCategory nqtCategory)
        {
            if (id != nqtCategory.NqtCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nqtCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NqtCategoryExists(nqtCategory.NqtCategoryId))
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
            return View(nqtCategory);
        }

        // GET: NqtCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtCategory = await _context.NqtCategories
                .FirstOrDefaultAsync(m => m.NqtCategoryId == id);
            if (nqtCategory == null)
            {
                return NotFound();
            }

            return View(nqtCategory);
        }

        // POST: NqtCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nqtCategory = await _context.NqtCategories.FindAsync(id);
            if (nqtCategory != null)
            {
                _context.NqtCategories.Remove(nqtCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NqtCategoryExists(int id)
        {
            return _context.NqtCategories.Any(e => e.NqtCategoryId == id);
        }
    }
}

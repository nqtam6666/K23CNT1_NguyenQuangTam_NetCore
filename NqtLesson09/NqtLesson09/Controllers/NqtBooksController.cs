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
    public class NqtBooksController : Controller
    {
        private readonly NqtBookStoreBookStoreContext _context;

        public NqtBooksController(NqtBookStoreBookStoreContext context)
        {
            _context = context;
        }

        // GET: NqtBooks
        public async Task<IActionResult> Index()
        {
            var nqtBookStoreBookStoreContext = _context.NqtBooks.Include(n => n.NqtCategory).Include(n => n.NqtPublisher);
            return View(await nqtBookStoreBookStoreContext.ToListAsync());
        }

        // GET: NqtBooks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtBook = await _context.NqtBooks
                .Include(n => n.NqtCategory)
                .Include(n => n.NqtPublisher)
                .FirstOrDefaultAsync(m => m.NqtBookId == id);
            if (nqtBook == null)
            {
                return NotFound();
            }

            return View(nqtBook);
        }

        // GET: NqtBooks/Create
        public IActionResult Create()
        {
            ViewData["NqtCategoryId"] = new SelectList(_context.NqtCategories, "NqtCategoryId", "NqtCategoryId");
            ViewData["NqtPublisherId"] = new SelectList(_context.NqtPublishers, "NqtPublisherId", "NqtPublisherId");
            return View();
        }

        // POST: NqtBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NqtBookId,NqtTitle,NqtAuthor,NqtRelease,NqtPrice,NqtDescription,NqtPicture,NqtPublisherId,NqtCategoryId")] NqtBook nqtBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nqtBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NqtCategoryId"] = new SelectList(_context.NqtCategories, "NqtCategoryId", "NqtCategoryId", nqtBook.NqtCategoryId);
            ViewData["NqtPublisherId"] = new SelectList(_context.NqtPublishers, "NqtPublisherId", "NqtPublisherId", nqtBook.NqtPublisherId);
            return View(nqtBook);
        }

        // GET: NqtBooks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtBook = await _context.NqtBooks.FindAsync(id);
            if (nqtBook == null)
            {
                return NotFound();
            }
            ViewData["NqtCategoryId"] = new SelectList(_context.NqtCategories, "NqtCategoryId", "NqtCategoryId", nqtBook.NqtCategoryId);
            ViewData["NqtPublisherId"] = new SelectList(_context.NqtPublishers, "NqtPublisherId", "NqtPublisherId", nqtBook.NqtPublisherId);
            return View(nqtBook);
        }

        // POST: NqtBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NqtBookId,NqtTitle,NqtAuthor,NqtRelease,NqtPrice,NqtDescription,NqtPicture,NqtPublisherId,NqtCategoryId")] NqtBook nqtBook)
        {
            if (id != nqtBook.NqtBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nqtBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NqtBookExists(nqtBook.NqtBookId))
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
            ViewData["NqtCategoryId"] = new SelectList(_context.NqtCategories, "NqtCategoryId", "NqtCategoryId", nqtBook.NqtCategoryId);
            ViewData["NqtPublisherId"] = new SelectList(_context.NqtPublishers, "NqtPublisherId", "NqtPublisherId", nqtBook.NqtPublisherId);
            return View(nqtBook);
        }

        // GET: NqtBooks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtBook = await _context.NqtBooks
                .Include(n => n.NqtCategory)
                .Include(n => n.NqtPublisher)
                .FirstOrDefaultAsync(m => m.NqtBookId == id);
            if (nqtBook == null)
            {
                return NotFound();
            }

            return View(nqtBook);
        }

        // POST: NqtBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nqtBook = await _context.NqtBooks.FindAsync(id);
            if (nqtBook != null)
            {
                _context.NqtBooks.Remove(nqtBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NqtBookExists(string id)
        {
            return _context.NqtBooks.Any(e => e.NqtBookId == id);
        }
    }
}

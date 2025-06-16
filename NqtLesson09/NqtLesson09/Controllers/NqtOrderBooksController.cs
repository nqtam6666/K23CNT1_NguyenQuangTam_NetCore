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
    public class NqtOrderBooksController : Controller
    {
        private readonly NqtBookStoreBookStoreContext _context;

        public NqtOrderBooksController(NqtBookStoreBookStoreContext context)
        {
            _context = context;
        }

        // GET: NqtOrderBooks
        public async Task<IActionResult> Index()
        {
            var nqtBookStoreBookStoreContext = _context.NqtOrderBooks.Include(n => n.NqtAccount);
            return View(await nqtBookStoreBookStoreContext.ToListAsync());
        }

        // GET: NqtOrderBooks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtOrderBook = await _context.NqtOrderBooks
                .Include(n => n.NqtAccount)
                .FirstOrDefaultAsync(m => m.NqtOrderId == id);
            if (nqtOrderBook == null)
            {
                return NotFound();
            }

            return View(nqtOrderBook);
        }

        // GET: NqtOrderBooks/Create
        public IActionResult Create()
        {
            ViewData["NqtAccountId"] = new SelectList(_context.NqtAccounts, "NqtAccountId", "NqtAccountId");
            return View();
        }

        // POST: NqtOrderBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NqtOrderId,NqtOrderDate,NqtAccountId,NqtReceiveAddress,NqtReceivePhone,NqtOrderReceive,NqtNote,NqtStatus")] NqtOrderBook nqtOrderBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nqtOrderBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NqtAccountId"] = new SelectList(_context.NqtAccounts, "NqtAccountId", "NqtAccountId", nqtOrderBook.NqtAccountId);
            return View(nqtOrderBook);
        }

        // GET: NqtOrderBooks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtOrderBook = await _context.NqtOrderBooks.FindAsync(id);
            if (nqtOrderBook == null)
            {
                return NotFound();
            }
            ViewData["NqtAccountId"] = new SelectList(_context.NqtAccounts, "NqtAccountId", "NqtAccountId", nqtOrderBook.NqtAccountId);
            return View(nqtOrderBook);
        }

        // POST: NqtOrderBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NqtOrderId,NqtOrderDate,NqtAccountId,NqtReceiveAddress,NqtReceivePhone,NqtOrderReceive,NqtNote,NqtStatus")] NqtOrderBook nqtOrderBook)
        {
            if (id != nqtOrderBook.NqtOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nqtOrderBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NqtOrderBookExists(nqtOrderBook.NqtOrderId))
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
            ViewData["NqtAccountId"] = new SelectList(_context.NqtAccounts, "NqtAccountId", "NqtAccountId", nqtOrderBook.NqtAccountId);
            return View(nqtOrderBook);
        }

        // GET: NqtOrderBooks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtOrderBook = await _context.NqtOrderBooks
                .Include(n => n.NqtAccount)
                .FirstOrDefaultAsync(m => m.NqtOrderId == id);
            if (nqtOrderBook == null)
            {
                return NotFound();
            }

            return View(nqtOrderBook);
        }

        // POST: NqtOrderBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nqtOrderBook = await _context.NqtOrderBooks.FindAsync(id);
            if (nqtOrderBook != null)
            {
                _context.NqtOrderBooks.Remove(nqtOrderBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NqtOrderBookExists(string id)
        {
            return _context.NqtOrderBooks.Any(e => e.NqtOrderId == id);
        }
    }
}

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
    public class NqtPublishersController : Controller
    {
        private readonly NqtBookStoreBookStoreContext _context;

        public NqtPublishersController(NqtBookStoreBookStoreContext context)
        {
            _context = context;
        }

        // GET: NqtPublishers
        public async Task<IActionResult> Index()
        {
            return View(await _context.NqtPublishers.ToListAsync());
        }

        // GET: NqtPublishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtPublisher = await _context.NqtPublishers
                .FirstOrDefaultAsync(m => m.NqtPublisherId == id);
            if (nqtPublisher == null)
            {
                return NotFound();
            }

            return View(nqtPublisher);
        }

        // GET: NqtPublishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NqtPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NqtPublisherId,NqtPublisherName,NqtPhone,NqtAddress")] NqtPublisher nqtPublisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nqtPublisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nqtPublisher);
        }

        // GET: NqtPublishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtPublisher = await _context.NqtPublishers.FindAsync(id);
            if (nqtPublisher == null)
            {
                return NotFound();
            }
            return View(nqtPublisher);
        }

        // POST: NqtPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NqtPublisherId,NqtPublisherName,NqtPhone,NqtAddress")] NqtPublisher nqtPublisher)
        {
            if (id != nqtPublisher.NqtPublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nqtPublisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NqtPublisherExists(nqtPublisher.NqtPublisherId))
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
            return View(nqtPublisher);
        }

        // GET: NqtPublishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtPublisher = await _context.NqtPublishers
                .FirstOrDefaultAsync(m => m.NqtPublisherId == id);
            if (nqtPublisher == null)
            {
                return NotFound();
            }

            return View(nqtPublisher);
        }

        // POST: NqtPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nqtPublisher = await _context.NqtPublishers.FindAsync(id);
            if (nqtPublisher != null)
            {
                _context.NqtPublishers.Remove(nqtPublisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NqtPublisherExists(int id)
        {
            return _context.NqtPublishers.Any(e => e.NqtPublisherId == id);
        }
    }
}

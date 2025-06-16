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
    public class NqtOrderDetailsController : Controller
    {
        private readonly NqtBookStoreBookStoreContext _context;

        public NqtOrderDetailsController(NqtBookStoreBookStoreContext context)
        {
            _context = context;
        }

        // GET: NqtOrderDetails
        public async Task<IActionResult> Index()
        {
            var nqtBookStoreBookStoreContext = _context.NqtOrderDetails.Include(n => n.NqtBook).Include(n => n.NqtOrder);
            return View(await nqtBookStoreBookStoreContext.ToListAsync());
        }

        // GET: NqtOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtOrderDetail = await _context.NqtOrderDetails
                .Include(n => n.NqtBook)
                .Include(n => n.NqtOrder)
                .FirstOrDefaultAsync(m => m.NqtOrderDetailId == id);
            if (nqtOrderDetail == null)
            {
                return NotFound();
            }

            return View(nqtOrderDetail);
        }

        // GET: NqtOrderDetails/Create
        public IActionResult Create()
        {
            ViewData["NqtBookId"] = new SelectList(_context.NqtBooks, "NqtBookId", "NqtBookId");
            ViewData["NqtOrderId"] = new SelectList(_context.NqtOrderBooks, "NqtOrderId", "NqtOrderId");
            return View();
        }

        // POST: NqtOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NqtOrderDetailId,NqtOrderId,NqtBookId,NqtQuantity,NqtPrice,NqtTotalMoney")] NqtOrderDetail nqtOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nqtOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NqtBookId"] = new SelectList(_context.NqtBooks, "NqtBookId", "NqtBookId", nqtOrderDetail.NqtBookId);
            ViewData["NqtOrderId"] = new SelectList(_context.NqtOrderBooks, "NqtOrderId", "NqtOrderId", nqtOrderDetail.NqtOrderId);
            return View(nqtOrderDetail);
        }

        // GET: NqtOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtOrderDetail = await _context.NqtOrderDetails.FindAsync(id);
            if (nqtOrderDetail == null)
            {
                return NotFound();
            }
            ViewData["NqtBookId"] = new SelectList(_context.NqtBooks, "NqtBookId", "NqtBookId", nqtOrderDetail.NqtBookId);
            ViewData["NqtOrderId"] = new SelectList(_context.NqtOrderBooks, "NqtOrderId", "NqtOrderId", nqtOrderDetail.NqtOrderId);
            return View(nqtOrderDetail);
        }

        // POST: NqtOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NqtOrderDetailId,NqtOrderId,NqtBookId,NqtQuantity,NqtPrice,NqtTotalMoney")] NqtOrderDetail nqtOrderDetail)
        {
            if (id != nqtOrderDetail.NqtOrderDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nqtOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NqtOrderDetailExists(nqtOrderDetail.NqtOrderDetailId))
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
            ViewData["NqtBookId"] = new SelectList(_context.NqtBooks, "NqtBookId", "NqtBookId", nqtOrderDetail.NqtBookId);
            ViewData["NqtOrderId"] = new SelectList(_context.NqtOrderBooks, "NqtOrderId", "NqtOrderId", nqtOrderDetail.NqtOrderId);
            return View(nqtOrderDetail);
        }

        // GET: NqtOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtOrderDetail = await _context.NqtOrderDetails
                .Include(n => n.NqtBook)
                .Include(n => n.NqtOrder)
                .FirstOrDefaultAsync(m => m.NqtOrderDetailId == id);
            if (nqtOrderDetail == null)
            {
                return NotFound();
            }

            return View(nqtOrderDetail);
        }

        // POST: NqtOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nqtOrderDetail = await _context.NqtOrderDetails.FindAsync(id);
            if (nqtOrderDetail != null)
            {
                _context.NqtOrderDetails.Remove(nqtOrderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NqtOrderDetailExists(int id)
        {
            return _context.NqtOrderDetails.Any(e => e.NqtOrderDetailId == id);
        }
    }
}

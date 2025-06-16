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
    public class NqtAccountsController : Controller
    {
        private readonly NqtBookStoreBookStoreContext _context;

        public NqtAccountsController(NqtBookStoreBookStoreContext context)
        {
            _context = context;
        }

        // GET: NqtAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.NqtAccounts.ToListAsync());
        }

        // GET: NqtAccounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtAccount = await _context.NqtAccounts
                .FirstOrDefaultAsync(m => m.NqtAccountId == id);
            if (nqtAccount == null)
            {
                return NotFound();
            }

            return View(nqtAccount);
        }

        // GET: NqtAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NqtAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NqtAccountId,NqtUsername,NqtPassword,NqtFullName,NqtPicture,NqtEmail,NqtAddress,NqtPhone,NqtIsAdmin,NqtActive")] NqtAccount nqtAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nqtAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nqtAccount);
        }

        // GET: NqtAccounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtAccount = await _context.NqtAccounts.FindAsync(id);
            if (nqtAccount == null)
            {
                return NotFound();
            }
            return View(nqtAccount);
        }

        // POST: NqtAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NqtAccountId,NqtUsername,NqtPassword,NqtFullName,NqtPicture,NqtEmail,NqtAddress,NqtPhone,NqtIsAdmin,NqtActive")] NqtAccount nqtAccount)
        {
            if (id != nqtAccount.NqtAccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nqtAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NqtAccountExists(nqtAccount.NqtAccountId))
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
            return View(nqtAccount);
        }

        // GET: NqtAccounts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtAccount = await _context.NqtAccounts
                .FirstOrDefaultAsync(m => m.NqtAccountId == id);
            if (nqtAccount == null)
            {
                return NotFound();
            }

            return View(nqtAccount);
        }

        // POST: NqtAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nqtAccount = await _context.NqtAccounts.FindAsync(id);
            if (nqtAccount != null)
            {
                _context.NqtAccounts.Remove(nqtAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NqtAccountExists(string id)
        {
            return _context.NqtAccounts.Any(e => e.NqtAccountId == id);
        }
    }
}

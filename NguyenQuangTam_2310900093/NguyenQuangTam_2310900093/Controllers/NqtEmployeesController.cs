using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenQuangTam_2310900093.Models;

namespace NguyenQuangTam_2310900093.Controllers
{
    public class NqtEmployeesController : Controller
    {
        private readonly NguyenQuangTam2310900093Context _context;

        public NqtEmployeesController(NguyenQuangTam2310900093Context context)
        {
            _context = context;
        }

        // GET: NqtEmployees
        public async Task<IActionResult>  NqtIndex()
        {
            return View(await _context.NqtEmployees.ToListAsync());
        }

        // GET: NqtEmployees/Details/5
        public async Task<IActionResult> NqtDetails(int? Nqtid)
        {
            if (Nqtid == null)
            {
                return NotFound();
            }

            var nqtEmployee = await _context.NqtEmployees
                .FirstOrDefaultAsync(m => m.NqtEmpId == Nqtid);
            if (nqtEmployee == null)
            {
                return NotFound();
            }

            return View(nqtEmployee);
        }

        // GET: NqtEmployees/Create
        public IActionResult NqtCreate()
        {
            return View();
        }

        // POST: NqtEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtCreate([Bind("NqtEmpId,NqtEmpName,NqtEmpLevel,NqtEmpStartDate,NqtEmpStatus")] NqtEmployee nqtEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nqtEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NqtIndex));
            }
            return View(nqtEmployee);
        }

        // GET: NqtEmployees/Edit/5
        public async Task<IActionResult> NqtEdit(int? Nqtid)
        {
            if (Nqtid == null)
            {
                return NotFound();
            }

            var nqtEmployee = await _context.NqtEmployees.FindAsync(Nqtid);
            if (nqtEmployee == null)
            {
                return NotFound();
            }
            return View(nqtEmployee);
        }

        // POST: NqtEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtEdit(int Nqtid, [Bind("NqtEmpId,NqtEmpName,NqtEmpLevel,NqtEmpStartDate,NqtEmpStatus")] NqtEmployee nqtEmployee)
        {
            if (Nqtid != nqtEmployee.NqtEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nqtEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NqtEmployeeExists(nqtEmployee.NqtEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NqtIndex));
            }
            return View(nqtEmployee);
        }

        // GET: NqtEmployees/Delete/5
        public async Task<IActionResult> NqtDelete(int? Nqtid)
        {
            if (Nqtid == null)
            {
                return NotFound();
            }

            var nqtEmployee = await _context.NqtEmployees
                .FirstOrDefaultAsync(m => m.NqtEmpId == Nqtid);
            if (nqtEmployee == null)
            {
                return NotFound();
            }

            return View(nqtEmployee);
        }

        // POST: NqtEmployees/Delete/5
        [HttpPost, ActionName("NqtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Nqtid)
        {
            var nqtEmployee = await _context.NqtEmployees.FindAsync(Nqtid);
            if (nqtEmployee != null)
            {
                _context.NqtEmployees.Remove(nqtEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NqtIndex));
        }

        private bool NqtEmployeeExists(int Nqtid)
        {
            return _context.NqtEmployees.Any(e => e.NqtEmpId == Nqtid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NqtLesson10.Models;

namespace NqtLesson10.Controllers
{
    public class NqtPostsController : Controller
    {
        private readonly NqtK23cnt1Lesson10Context _context;

        public NqtPostsController(NqtK23cnt1Lesson10Context context)
        {
            _context = context;
        }

        // GET: NqtPosts
        public async Task<IActionResult> NqtIndex()
        {
            return View(await _context.NqtPosts.ToListAsync());
        }

        // GET: NqtPosts/Details/5
        public async Task<IActionResult> NqtDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtPost = await _context.NqtPosts
                .FirstOrDefaultAsync(m => m.NqtId == id);
            if (nqtPost == null)
            {
                return NotFound();
            }

            return View(nqtPost);
        }

        // GET: NqtPosts/NqtCreate
        public IActionResult NqtCreate()
        {
            return View();
        }

        // POST: NqtPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtCreate([Bind("NqtId,NqtTitle,NqtImage,NqtText,NqtStatus")] NqtPost nqtPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nqtPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nqtPost);
        }

        // GET: NqtPosts/Edit/5
        public async Task<IActionResult> NqtEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtPost = await _context.NqtPosts.FindAsync(id);
            if (nqtPost == null)
            {
                return NotFound();
            }
            return View(nqtPost);
        }

        // POST: NqtPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtEdit(int id, [Bind("NqtId,NqtTitle,NqtImage,NqtText,NqtStatus")] NqtPost nqtPost)
        {
            if (id != nqtPost.NqtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nqtPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NqtPostExists(nqtPost.NqtId))
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
            return View(nqtPost);
        }

        // GET: NqtPosts/Delete/5
        public async Task<IActionResult> NqtDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nqtPost = await _context.NqtPosts
                .FirstOrDefaultAsync(m => m.NqtId == id);
            if (nqtPost == null)
            {
                return NotFound();
            }

            return View(nqtPost);
        }

        // POST: NqtPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nqtPost = await _context.NqtPosts.FindAsync(id);
            if (nqtPost != null)
            {
                _context.NqtPosts.Remove(nqtPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NqtPostExists(int id)
        {
            return _context.NqtPosts.Any(e => e.NqtId == id);
        }
    }
}

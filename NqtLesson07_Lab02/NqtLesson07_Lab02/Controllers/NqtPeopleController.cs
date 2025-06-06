using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NqtLesson07_Lab02.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NqtLesson07_Lab02.Controllers
{
    public class NqtPeopleController : Controller
    {
        private readonly DataLocal _context;

        public NqtPeopleController(DataLocal context)
        {
            _context = context;
        }

        // GET: NqtPeopleController
        public ActionResult NqtIndex()
        {
            var peoples = _context.GetNqtPeoples();
            return View(peoples);
        }

        // GET: NqtPeopleController/NqtDetails/5
        public ActionResult NqtDetails(int id)
        {
            var people = _context.GetNqtPeopleByNqtID(id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }

        // GET: NqtPeopleController/NqtCreate
        public ActionResult NqtCreate()
        {
            return View();
        }

        // POST: NqtPeopleController/NqtCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtCreate([Bind("NqtID,NqtName,NqtEmail,NqtPhone,NqtAddress,NqtAvatar,NqtBirthday,NqtBio,NqtGender")] NqtPeople model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Xử lý upload file cho NqtAvatar
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0 && files[0].Length > 0)
                    {
                        var file = files[0];
                        var fileName = $"{Guid.NewGuid()}_{file.FileName}"; // Thêm GUID để tránh ghi đè
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/avatar", fileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(path));

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        model.NqtAvatar = $"/images/avatar/{fileName}";
                    }

                    _context.Add(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(NqtIndex));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            return View(model);
        }

        // GET: NqtPeopleController/NqtEdit/5
        public ActionResult NqtEdit(int id)
        {
            var people = _context.GetNqtPeopleByNqtID(id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }

        // POST: NqtPeopleController/NqtEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtEdit(int id, [Bind("NqtID,NqtName,NqtEmail,NqtPhone,NqtAddress,NqtAvatar,NqtBirthday,NqtBio,NqtGender")] NqtPeople model)
        {
            if (id != model.NqtID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0 && files[0].Length > 0)
                    {
                        var file = files[0];
                        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/avatar", fileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(path));

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        model.NqtAvatar = $"/images/avatar/{fileName}";
                    }

                    _context.Update(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(NqtIndex));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            return View(model);
        }

        // GET: NqtPeopleController/NqtDelete/5
        public ActionResult NqtDelete(int id)
        {
            var people = _context.GetNqtPeopleByNqtID(id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }

        // POST: NqtPeopleController/NqtDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtDeleteConfirmed(int id) // Renamed to avoid conflict
        {
            try
            {
                var people = _context.GetNqtPeopleByNqtID(id);
                if (people != null)
                {
                    _context.Remove(people);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(NqtIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
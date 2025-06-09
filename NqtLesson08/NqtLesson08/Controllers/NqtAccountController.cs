using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NqtLesson08.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NqtLesson08.Controllers
{
    public class NqtAccountController : Controller
    {
        // In-memory list to simulate a database
        private static List<NqtAccount> _accounts = new List<NqtAccount>
        {
            new NqtAccount
            {
                NqtId = 1,
                NqtFullName = "Nguyễn Quang Tâm",
                NqtEmail = "nguyenquangtam6666@gmail.com",
                NqtPhone = "0961138440",
                NqtAddress = "Hà Nội",
                NqtAvatar = "/images/avatar1.jpg",
                NqtBirthday = new DateTime(2005, 6, 26),
                NqtGender = "Nam",
                NqtPassword = "123456",
                NqtFacebook = "https://facebook.com/nqtam6666"
            },
            new NqtAccount
            {
                NqtId = 2,
                NqtFullName = "Trần Thị B",
                NqtEmail = "thib@example.com",
                NqtPhone = "0911123456",
                NqtAddress = "TP. Hồ Chí Minh",
                NqtAvatar = "/images/avatar2.jpg",
                NqtBirthday = new DateTime(1998, 8, 15),
                NqtGender = "Nữ",
                NqtPassword = "abcdef",
                NqtFacebook = "https://facebook.com/tranthib"
            }
        };

        // GET: NqtAccount/VerifyPhone
        // GET: NqtAccount/VerifyPhone
        [HttpGet]
        public IActionResult VerifyPhone(string NqtPhone)
        {
            if (string.IsNullOrEmpty(NqtPhone))
            {
                return Json(false); // Trả về false thay vì object phức tạp
            }

            // Kiểm tra định dạng số điện thoại Việt Nam
            Regex phoneRegex = new Regex(@"^(0[3|5|7|8|9])+([0-9]{8})$");
            if (!phoneRegex.IsMatch(NqtPhone))
            {
                return Json($"Số điện thoại {NqtPhone} không đúng định dạng số điện thoại Việt Nam.");
            }

            // Kiểm tra trùng lặp (nếu cần)
            var existingAccount = _accounts.FirstOrDefault(a => a.NqtPhone == NqtPhone);
            if (existingAccount != null)
            {
                return Json($"Số điện thoại {NqtPhone} đã được sử dụng.");
            }

            return Json(true);
        }

        // GET: NqtAccount
        public IActionResult NqtIndex()
        {
            return View(_accounts);
        }

        // GET: NqtAccount/Details/5
        public IActionResult NqtDetails(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.NqtId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // GET: NqtAccount/Create
        public IActionResult NqtCreate()
        {
            return View(new NqtAccount());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NqtCreate(NqtAccount account)
        {
            // Debug: Kiểm tra lỗi validation
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}");
                    foreach (var subError in error.Value.Errors)
                    {
                        Console.WriteLine($"Error: {subError.ErrorMessage}");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                account.NqtId = _accounts.Any() ? _accounts.Max(a => a.NqtId) + 1 : 1;
                _accounts.Add(account);
                return RedirectToAction(nameof(NqtIndex));
            }
            return View(account);
        }

        // GET: NqtAccount/Edit/5
        public IActionResult NqtEdit(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.NqtId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: NqtAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NqtEdit(int id, NqtAccount account)
        {
            if (id != account.NqtId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingAccount = _accounts.FirstOrDefault(a => a.NqtId == id);
                if (existingAccount == null)
                {
                    return NotFound();
                }

                // Update fields
                existingAccount.NqtFullName = account.NqtFullName;
                existingAccount.NqtEmail = account.NqtEmail;
                existingAccount.NqtPhone = account.NqtPhone;
                existingAccount.NqtAddress = account.NqtAddress;
                existingAccount.NqtAvatar = account.NqtAvatar;
                existingAccount.NqtBirthday = account.NqtBirthday;
                existingAccount.NqtGender = account.NqtGender;
                existingAccount.NqtPassword = account.NqtPassword;
                existingAccount.NqtFacebook = account.NqtFacebook;

                return RedirectToAction(nameof(NqtIndex));
            }
            return View(account);
        }

        // GET: NqtAccount/Delete/5
        public IActionResult NqtDelete(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.NqtId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: NqtAccount/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NqtDelete(int id, IFormCollection collection)
        {
            var account = _accounts.FirstOrDefault(a => a.NqtId == id);
            if (account == null)
            {
                return NotFound();
            }
            _accounts.Remove(account);
            return RedirectToAction(nameof(NqtIndex));
        }
    }
}
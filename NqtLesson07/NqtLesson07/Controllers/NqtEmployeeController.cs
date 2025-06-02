using Microsoft.AspNetCore.Mvc;
using NqtLesson07.Models;
using System;
using System.Collections.Generic;

namespace NqtLesson07.Controllers
{
    public class NqtEmployeeController : Controller
    {
        private static List<NqtEmployee> NqtEmployees = new List<NqtEmployee>
        {
            new NqtEmployee
            {
                NqtID = 231090009,
                NqtName = "Nguyễn Quang Tâm",
                NqtEmail = "nguyenquangtam179@gmail.com",
                NqtBirthDay = new DateTime(2005, 6, 26),
                NqtPhone = "0961138440",
                NqtSalary = 12000000,
                NqtStatus = true
            },
            new NqtEmployee
            {
                NqtID = 2,
                NqtName = "Trần Thị B",
                NqtEmail = "b.tran@example.com",
                NqtBirthDay = new DateTime(1992, 3, 10),
                NqtPhone = "0912345678",
                NqtSalary = 10000000,
                NqtStatus = true
            },
            new NqtEmployee
            {
                NqtID = 3,
                NqtName = "Lê Văn C",
                NqtEmail = "c.le@example.com",
                NqtBirthDay = new DateTime(1988, 7, 22),
                NqtPhone = "0987654321",
                NqtSalary = 15000000,
                NqtStatus = false
            },
            new NqtEmployee
            {
                NqtID = 4,
                NqtName = "Phạm Thị D",
                NqtEmail = "d.pham@example.com",
                NqtBirthDay = new DateTime(1995, 11, 5),
                NqtPhone = "0934567890",
                NqtSalary = 13000000,
                NqtStatus = true
            },
            new NqtEmployee
            {
                NqtID = 5,
                NqtName = "Đỗ Văn E",
                NqtEmail = "e.do@example.com",
                NqtBirthDay = new DateTime(1985, 9, 30),
                NqtPhone = "0976543210",
                NqtSalary = 11000000,
                NqtStatus = false
            },
            new NqtEmployee
            {
                NqtID = 6,
                NqtName = "Hoàng Thị F",
                NqtEmail = "f.hoang@example.com",
                NqtBirthDay = new DateTime(1998, 4, 25),
                NqtPhone = "0961234567",
                NqtSalary = 9500000,
                NqtStatus = true
            }
        };

        public IActionResult NqtIndex()
        {
            return View(NqtEmployees); // truyền danh sách ra view
        }
        // GET: Hiển thị form tạo mới
        public IActionResult NqtCreate()
        {
            return View();
        }

        // POST: Xử lý form tạo mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NqtCreate(NqtEmployee employee)
        {
            if (ModelState.IsValid)
            {
                NqtEmployees.Add(employee);
                return RedirectToAction("NqtIndex");
            }
            return View(employee);
        }

        public IActionResult NqtEdit(int id)
        {
            var model = NqtEmployees.Find(x => x.NqtID == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NqtEdit(NqtEmployee updated)
        {
            var existing = NqtEmployees.Find(x => x.NqtID == updated.NqtID);
            if (existing == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existing.NqtName = updated.NqtName;
                existing.NqtEmail = updated.NqtEmail;
                existing.NqtBirthDay = updated.NqtBirthDay;
                existing.NqtPhone = updated.NqtPhone;
                existing.NqtSalary = updated.NqtSalary;
                existing.NqtStatus = updated.NqtStatus;

                return RedirectToAction("NqtIndex");
            }

            return View(updated);
        }
        // GET: Nqt/NqtDetails/5
        public IActionResult NqtDetail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var employee = NqtEmployees.FirstOrDefault(x => x.NqtID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        public IActionResult NqtDelete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var employee = NqtEmployees.FirstOrDefault(x => x.NqtID == id);
            if (employee == null)
            {
                return NotFound();
            }

            NqtEmployees.Remove(employee);
            TempData["Message"] = $"Xóa nhân viên {employee.NqtName} thành công!";
            return RedirectToAction("NqtIndex");
        }

    }
}

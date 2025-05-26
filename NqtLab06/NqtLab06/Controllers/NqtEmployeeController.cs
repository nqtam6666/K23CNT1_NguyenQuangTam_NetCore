using Microsoft.AspNetCore.Mvc;
using NqtLab06.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq; // Added for LINQ methods like Any() and Max()

public class NqtEmployeeController : Controller
{
    // Static list to store employees (in-memory for simplicity)
    private static List<NqtEmployee> _accounts = new List<NqtEmployee>
    {
        new NqtEmployee
        {
            NqtID = 1,
            NqtName = "Nguyễn Quang Tâm",
            NqtEmail = "nguyenquangtam6666@gmail.com",
            NqtBirthDay = DateTime.ParseExact("2005/06/26", "yyyy/MM/dd", CultureInfo.InvariantCulture),
            NqtPhone = "0961138440",
            NqtSalary = 600000.0,
            NqtStatus = true
        },
        new NqtEmployee
        {
            NqtID = 2,
            NqtName = "Trần Thị Minh Anh",
            NqtEmail = "tranminhanh123@gmail.com",
            NqtBirthDay = DateTime.ParseExact("1998/03/15", "yyyy/MM/dd", CultureInfo.InvariantCulture),
            NqtPhone = "0912345678",
            NqtSalary = 750000.0,
            NqtStatus = true
        },
        new NqtEmployee
        {
            NqtID = 3,
            NqtName = "Lê Văn Hùng",
            NqtEmail = "levanhung456@gmail.com",
            NqtBirthDay = DateTime.ParseExact("2000/11/30", "yyyy/MM/dd", CultureInfo.InvariantCulture),
            NqtPhone = "0933456789",
            NqtSalary = 800000.0,
            NqtStatus = false
        },
        new NqtEmployee
        {
            NqtID = 4,
            NqtName = "Phạm Thị Ngọc",
            NqtEmail = "phamthingoc789@gmail.com",
            NqtBirthDay = DateTime.ParseExact("1995/07/22", "yyyy/MM/dd", CultureInfo.InvariantCulture),
            NqtPhone = "0987654321",
            NqtSalary = 900000.0,
            NqtStatus = true
        },
        new NqtEmployee
        {
            NqtID = 5,
            NqtName = "Hoàng Minh Tuấn",
            NqtEmail = "hoangminhtuan101@gmail.com",
            NqtBirthDay = DateTime.ParseExact("2002/09/10", "yyyy/MM/dd", CultureInfo.InvariantCulture),
            NqtPhone = "0901234567",
            NqtSalary = 650000.0,
            NqtStatus = false
        },
        new NqtEmployee
        {
            NqtID = 6,
            NqtName = "Vũ Thị Lan",
            NqtEmail = "vuthilan202@gmail.com",
            NqtBirthDay = DateTime.ParseExact("1997/12/05", "yyyy/MM/dd", CultureInfo.InvariantCulture),
            NqtPhone = "0945678901",
            NqtSalary = 700000.0,
            NqtStatus = true
        }
    };

    // GET: /NqtEmployee/NqtListEmployee
    public IActionResult NqtListEmployee()
    {
        return View(_accounts);
    }

    // GET: /NqtEmployee/NqtCreate
    public IActionResult NqtCreate()
    {
        return View();
    }

    // POST: /NqtEmployee/NqtCreateSubmit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult NqtCreateSubmit(NqtEmployee employee)
    {
        if (ModelState.IsValid)
        {
            employee.NqtID = _accounts.Any() ? _accounts.Max(e => e.NqtID) + 1 : 1;
            _accounts.Add(employee);
            return RedirectToAction("NqtListEmployee");
        }
        return View("NqtCreate", employee);
    }

    // GET: /NqtEmployee/NqtEdit/{id}
    public IActionResult NqtEdit(int id)
    {
        var employee = _accounts.FirstOrDefault(e => e.NqtID == id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    // POST: /NqtEmployee/NqtEditSubmit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult NqtEditSubmit(int id, NqtEmployee employee)
    {
        if (id != employee.NqtID)
        {
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            var existingEmployee = _accounts.FirstOrDefault(e => e.NqtID == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            // Update fields
            existingEmployee.NqtName = employee.NqtName;
            existingEmployee.NqtEmail = employee.NqtEmail;
            existingEmployee.NqtBirthDay = employee.NqtBirthDay;
            existingEmployee.NqtPhone = employee.NqtPhone;
            existingEmployee.NqtSalary = employee.NqtSalary;
            existingEmployee.NqtStatus = employee.NqtStatus;
            return RedirectToAction("NqtListEmployee");
        }
        return View("NqtEdit", employee);
    }

    // POST: /NqtEmployee/NqtDelete/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult NqtDelete(int id)
    {
        var employee = _accounts.FirstOrDefault(e => e.NqtID == id);
        if (employee == null)
        {
            return NotFound();
        }
        _accounts.Remove(employee);
        return RedirectToAction("NqtListEmployee");
    }
}
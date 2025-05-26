using Microsoft.AspNetCore.Mvc;
using NqtLab06.Models;
using System.Diagnostics;

namespace NqtLab06.Controllers
{
    public class NqtHomeController : Controller
    {
        private readonly ILogger<NqtHomeController> _logger;

        public NqtHomeController(ILogger<NqtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NqtIndex()
        {
            return View();
        }

        public IActionResult NqtInfoStudent()
        {
            ViewBag.Info = new
            {
                HoVaTen = "Nguyễn Quang Tâm",
                Lop = "K23CNT1",
                SDT = "0961138440",
            };
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

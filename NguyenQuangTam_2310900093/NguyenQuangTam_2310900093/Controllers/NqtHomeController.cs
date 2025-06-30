using Microsoft.AspNetCore.Mvc;
using NguyenQuangTam_2310900093.Models;
using System.Diagnostics;

namespace NguyenQuangTam_2310900093.Controllers
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

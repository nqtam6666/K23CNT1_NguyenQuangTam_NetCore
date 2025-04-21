using Lesson1_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson1_mvc.Controllers
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

        public IActionResult NqtPrivacy()
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

using System.Diagnostics;
using lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
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
            var products = new List<NqtProduct>
            {
                new NqtProduct { Id = 1, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/product1.jpg" },
                new NqtProduct { Id = 2, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/product1.jpg" },
                new NqtProduct { Id = 3, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/product1.jpg" }
            };
            return View(products);
        }

        public IActionResult NqtAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult GetHotProducts()
        {
            // Giả lập dữ liệu (thay bằng truy vấn từ database nếu cần)
            var products = new List<NqtProduct>
        {
            new NqtProduct { Id = 1, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/product1.jpg" },
            new NqtProduct { Id = 2, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/product1.jpg" },
            new NqtProduct { Id = 3, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/product1.jpg" }
        };

            return PartialView("_NqtHotProduct", products);
        }
    }
}

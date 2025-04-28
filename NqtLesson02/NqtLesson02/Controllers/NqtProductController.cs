using Microsoft.AspNetCore.Mvc;
//using NqtProduct;

using NqtLesson02.Models; // Thêm dòng này
namespace NqtLesson02.Controllers
{
    public class NqtProductController : Controller
    {
        public IActionResult NqtIndex()
        {
            ViewData["messageData"] = "Dữ liệu từ viewData";
            ViewBag.messageData = "Dữ liệu từ viewBag";
            TempData["messageData"] = "Dữ liệu từ TempData";
            return View();
        }
        public IActionResult NqtGetProduct()
        {
            NqtProduct p = new NqtProduct
            {
                ProductID = 1,
                ProductName = "Bàn là",
                YearRelease = 2025,
                Price = 300000
            };
            ViewBag.productData = p;
            ViewData["ProductVD"] = p;
            return View();
        }
        public IActionResult NqtProducts()
        {
                List<NqtProduct> products = new List<NqtProduct>()
        {
            new NqtProduct() { ProductID = 1, ProductName = "Trek 820 - 2016", YearRelease = 2016, Price = 379.99 },
            new NqtProduct() { ProductID = 2, ProductName = "Ritchay Timberwolf Frameset - 2016", YearRelease = 2016, Price = 749.99 },
            new NqtProduct() { ProductID = 3, ProductName = "Surly Wednesday Frameset - 2016", YearRelease = 2016, Price = 999.99 },
            new NqtProduct() { ProductID = 4, ProductName = "Trek Fuel EX 8 29 - 2016", YearRelease = 2016, Price = 2899.99 },
            new NqtProduct() { ProductID = 5, ProductName = "Heller Shagam Frameset - 2016", YearRelease = 2016, Price = 1320.99 },
            new NqtProduct() { ProductID = 6, ProductName = "Surly Ice Cream Truck Frameset - 2016", YearRelease = 2016, Price = 469.99 },
            new NqtProduct() { ProductID = 7, ProductName = "Trek Slash 8 27.5 - 2016", YearRelease = 2016, Price = 3999.99 },
            new NqtProduct() { ProductID = 8, ProductName = "Trek Remedy 29 Carbon Frameset - 2016", YearRelease = 2016, Price = 1799.99 },
            new NqtProduct() { ProductID = 9, ProductName = "Trek Conduit+ - 2015", YearRelease = 2016, Price = 2999.99 },
            new NqtProduct() { ProductID = 10, ProductName = "Surly Straggler - 2016", YearRelease = 2016, Price = 1549.99 },
            new NqtProduct() { ProductID = 11, ProductName = "Surly Straggler 650b - 2016", YearRelease = 2016, Price = 1680.99 },
            new NqtProduct() { ProductID = 12, ProductName = "Electra Townie Original 21D - 2016", YearRelease = 2016, Price = 549.99 },
            new NqtProduct() { ProductID = 13, ProductName = "Electra Cruiser 1 (24-Inch) - 2016", YearRelease = 2016, Price = 269.99 },
            new NqtProduct() { ProductID = 14, ProductName = "Electra Girl's Hawaii 1 (16-inch) - 2015/2016", YearRelease = 2016, Price = 269.99 },
        };

                ViewBag.products = products;

                return View();
            }
    }
}

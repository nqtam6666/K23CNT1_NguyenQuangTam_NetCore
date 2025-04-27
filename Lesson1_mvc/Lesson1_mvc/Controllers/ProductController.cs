using Microsoft.AspNetCore.Mvc;
using Lesson1_mvc.Models;
using System;
using System.Collections.Generic;

namespace Lesson1_mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // Hardcoded product list for demonstration
            var products = new List<NqtProduct>
            {
                new NqtProduct { Id = 1, Name = "Product 1", Price = 500000, CreatedAt = new DateTime(2020, 12, 25), ImageUrl = "https://get.pxhere.com/photo/leather-bag-handbag-package-brand-briefcase-leather-bags-fashion-accessory-tote-bag-shoulder-bag-673931.jpg" },
                new NqtProduct { Id = 2, Name = "Product 2", Price = 700000, CreatedAt = new DateTime(2020, 12, 25), ImageUrl = "https://get.pxhere.com/photo/leather-bag-handbag-package-brand-briefcase-leather-bags-fashion-accessory-tote-bag-shoulder-bag-673931.jpg" },
                new NqtProduct { Id = 3, Name = "Product 3", Price = 550000, CreatedAt = new DateTime(2020, 12, 25), ImageUrl = "https://get.pxhere.com/photo/leather-bag-handbag-package-brand-briefcase-leather-bags-fashion-accessory-tote-bag-shoulder-bag-673931.jpg" },
                new NqtProduct { Id = 4, Name = "Product 4", Price = 550000, CreatedAt = new DateTime(2020, 12, 25), ImageUrl = "https://get.pxhere.com/photo/leather-bag-handbag-package-brand-briefcase-leather-bags-fashion-accessory-tote-bag-shoulder-bag-673931.jpg" }
            };

            return View(products);
        }
    }
}
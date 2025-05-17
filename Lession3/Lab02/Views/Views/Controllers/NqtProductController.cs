using Microsoft.AspNetCore.Mvc;
using Views.Models;
using Views.Services;

namespace Views.Controllers
{
    public class ProductIndexViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public List<Views.Models.NqtCategory> Categories { get; set; } // Fixed namespace
        public int? SelectedCategoryId { get; set; }
    }

    public class NqtProductController : Controller
    {
        private readonly IProductService _productService;

        public NqtProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult NqtIndex(int? categoryId)
        {
            var viewModel = new ProductIndexViewModel
            {
                Products = _productService.GetAllProducts(categoryId),
                Categories = _productService.GetAllCategories(),
                SelectedCategoryId = categoryId
            };
            return View(viewModel);
        }

        [Route("chi-tiet-san-pham/{id}", Name = "product")]
        public IActionResult NqtProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
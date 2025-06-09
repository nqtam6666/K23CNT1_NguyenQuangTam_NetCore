using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NqtLesson08_ThucHanh.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace NqtLesson08_ThucHanh.Controllers
{
    public class NqtProductController : Controller
    {
        private readonly string _uploadsFolder;
        private static List<NqtProduct> _products = GetSampleProducts(); // Danh sách tĩnh
        private static List<NqtCategory> _categories = GetSampleCategories(); // Danh sách danh mục tĩnh

        public NqtProductController()
        {
            _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products");
            if (!Directory.Exists(_uploadsFolder))
            {
                Directory.CreateDirectory(_uploadsFolder);
            }
        }

        // GET: NqtProduct
        public async Task<IActionResult> NqtIndex()
        {
            return View(_products); // Sử dụng _products thay vì tạo danh sách mới
        }

        // GET: NqtProduct/Details/5
        public async Task<IActionResult> NqtDetails(int id)
        {
            var product = _products.FirstOrDefault(p => p.NqtId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: NqtProduct/Create
        public async Task<IActionResult> NqtCreate()
        {
            PopulateCategoryDropdown();
            return View();
        }

        // POST: NqtProduct/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtCreate([Bind("NqtId,NqtName,NqtPrice,NqtSalePrice,NqtDescription,NqtCategoryId")] NqtProduct product, IFormFile NqtImage)
        {
            if (NqtImage != null && NqtImage.Length > 0)
            {
                ModelState.Remove("NqtImage");
            }

            if (ModelState.IsValid)
            {
                if (NqtImage != null && NqtImage.Length > 0)
                {
                    var imagePath = await SaveImageAsync(NqtImage);
                    if (imagePath != null)
                    {
                        product.NqtImage = imagePath;
                    }
                    else
                    {
                        PopulateCategoryDropdown();
                        return View(product);
                    }
                }

                // Gán ID mới cho sản phẩm
                product.NqtId = _products.Any() ? _products.Max(p => p.NqtId) + 1 : 1;
                // Thêm sản phẩm vào danh sách tĩnh
                _products.Add(product);

                TempData["SuccessMessage"] = "Sản phẩm đã được tạo thành công!";
                return RedirectToAction(nameof(NqtIndex));
            }

            // Debug lỗi ModelState
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            foreach (var error in errors)
            {
                Console.WriteLine(error); // Ghi log lỗi để kiểm tra
            }

            PopulateCategoryDropdown();
            return View(product);
        }

        // GET: NqtProduct/Edit/5
        public async Task<IActionResult> NqtEdit(int id)
        {
            var product = _products.FirstOrDefault(p => p.NqtId == id);
            if (product == null)
            {
                return NotFound();
            }
            PopulateCategoryDropdown();
            return View(product);
        }

        // POST: NqtProduct/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtEdit(int id, [Bind("NqtId,NqtName,NqtPrice,NqtSalePrice,NqtDescription,NqtCategoryId")] NqtProduct product, IFormFile NqtImage)
        {
            if (id != product.NqtId)
            {
                return NotFound();
            }

            ModelState.Remove("NqtImage");

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProduct = _products.FirstOrDefault(p => p.NqtId == id);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }

                    if (NqtImage != null && NqtImage.Length > 0)
                    {
                        var imagePath = await SaveImageAsync(NqtImage);
                        if (imagePath != null)
                        {
                            product.NqtImage = imagePath;
                            if (!string.IsNullOrEmpty(existingProduct.NqtImage))
                            {
                                DeleteImage(existingProduct.NqtImage);
                            }
                        }
                        else
                        {
                            PopulateCategoryDropdown();
                            return View(product);
                        }
                    }
                    else
                    {
                        product.NqtImage = existingProduct.NqtImage;
                    }

                    // Cập nhật sản phẩm trong danh sách
                    var index = _products.FindIndex(p => p.NqtId == id);
                    _products[index] = product;

                    TempData["SuccessMessage"] = "Sản phẩm đã được cập nhật thành công!";
                    return RedirectToAction(nameof(NqtIndex));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật sản phẩm: " + ex.Message);
                }
            }

            PopulateCategoryDropdown();
            return View(product);
        }

        // GET: NqtProduct/Delete/5
        public async Task<IActionResult> NqtDelete(int id)
        {
            var product = _products.FirstOrDefault(p => p.NqtId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: NqtProduct/Delete/5
        [HttpPost, ActionName("NqtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NqtDeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.NqtId == id);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(product.NqtImage))
                {
                    DeleteImage(product.NqtImage);
                }
                _products.Remove(product);
                TempData["SuccessMessage"] = "Sản phẩm đã được xóa thành công!";
            }
            return RedirectToAction(nameof(NqtIndex));
        }

        #region Private Helper Methods

        private static List<NqtCategory> GetSampleCategories()
        {
            return new List<NqtCategory>
        {
            new NqtCategory { NqtId = 1, NqtName = "Điện thoại" },
            new NqtCategory { NqtId = 2, NqtName = "Laptop" },
            new NqtCategory { NqtId = 3, NqtName = "Tablet" }
        };
        }

        private void PopulateCategoryDropdown()
        {
            ViewBag.CategoryList = new SelectList(_categories, "NqtId", "NqtName");
        }

        private async Task<string> SaveImageAsync(IFormFile image)
        {
            try
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("NqtImage", "Chỉ chấp nhận file hình ảnh (jpg, jpeg, png, gif, bmp, webp).");
                    return null;
                }

                if (image.Length > 10 * 1024 * 1024)
                {
                    ModelState.AddModelError("NqtImage", "Kích thước file không được vượt quá 10MB.");
                    return null;
                }

                var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine(_uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                return "/products/" + uniqueFileName;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("NqtImage", "Có lỗi xảy ra khi upload hình ảnh: " + ex.Message);
                return null;
            }
        }

        private void DeleteImage(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath))
                {
                    var fileName = Path.GetFileName(imagePath);
                    var fullPath = Path.Combine(_uploadsFolder, fileName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
            }
        }

        private static List<NqtProduct> GetSampleProducts()
        {
            return new List<NqtProduct>
        {
            new NqtProduct
            {
                NqtId = 1,
                NqtName = "iPhone 15 Pro Max",
                NqtPrice = 29990000,
                NqtSalePrice = 27990000,
                NqtImage = "/products/iphone15promax.jpg",
                NqtDescription = "Điện thoại thông minh cao cấp với chip A17 Pro, camera 48MP và màn hình Super Retina XDR 6.7 inch",
                NqtCategoryId = 1
            },
            new NqtProduct
            {
                NqtId = 2,
                NqtName = "Samsung Galaxy S24 Ultra",
                NqtPrice = 31990000,
                NqtSalePrice = 29990000,
                NqtImage = "/products/samsung-s24-ultra.jpg",
                NqtDescription = "Smartphone Android flagship với bút S Pen, camera 200MP và màn hình Dynamic AMOLED 2X 6.8 inch",
                NqtCategoryId = 1
            },
            new NqtProduct
            {
                NqtId = 3,
                NqtName = "MacBook Pro M3",
                NqtPrice = 45990000,
                NqtSalePrice = 42990000,
                NqtImage = "/products/macbook-pro-m3.jpg",
                NqtDescription = "Laptop cao cấp với chip M3, màn hình Liquid Retina XDR 14 inch và thời lượng pin lên đến 22 giờ",
                NqtCategoryId = 2
            }
        };
        }

        #endregion
    }
}
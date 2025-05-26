using Views.Models;

namespace Views.Services
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
    }

    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts(int? categoryId = null);
        ProductViewModel GetProductById(int id);
        List<NqtCategory> GetAllCategories();
    }

    public class ProductService : IProductService
    {
        private readonly List<NqtProduct> _products;
        private readonly List<NqtCategory> _categories;

        public ProductService()
        {
            // Initialize categories
            _categories = new List<NqtCategory>
            {
                new NqtCategory { Id = 1, Name = "Đồ bơi trẻ em" },
                new NqtCategory { Id = 2, Name = "Đồ bơi người lớn" }
            };

            // Initialize products
            _products = new List<NqtProduct>
            {
                new NqtProduct
                {
                    Id = 1,
                    Name = "Bộ đồ bơi cho trẻ em nam",
                    Image = "images/bodoboi1.jpg",
                    Price = 150000,
                    SalePrice = 120000,
                    CategoryID = 1,
                    Description = "Bộ đồ bơi chất lượng cao, phù hợp cho trẻ em nam, thiết kế thoải mái và bền.",
                    CreateAt = DateTime.Parse("2024-06-26")
                },
                new NqtProduct
                {
                    Id = 2,
                    Name = "Bộ đồ bơi cho trẻ em nam cao cấp",
                    Image = "images/bodoboi2.jpg",
                    Price = 200000,
                    SalePrice = 180000,
                    CategoryID = 1,
                    Description = "Bộ đồ bơi cao cấp với thiết kế hiện đại, chống trơn trượt.",
                    CreateAt = DateTime.Parse("2024-06-27")
                },
                new NqtProduct
                {
                    Id = 3,
                    Name = "Bộ đồ bơi người lớn",
                    Image = "images/bodoboi3.jpg",
                    Price = 300000,
                    SalePrice = 270000,
                    CategoryID = 2,
                    Description = "Bộ đồ bơi dành cho người lớn, phong cách hiện đại.",
                    CreateAt = DateTime.Parse("2024-06-28")
                }
            };
        }

        public List<ProductViewModel> GetAllProducts(int? categoryId = null)
        {
            var query = _products.AsQueryable();
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryID == categoryId.Value);
            }

            var result = new List<ProductViewModel>();
            foreach (var p in query)
            {
                var category = _categories.FirstOrDefault(c => c.Id == p.CategoryID);
                result.Add(new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image,
                    Price = p.Price,
                    SalePrice = p.SalePrice,
                    CategoryName = category != null ? category.Name : "Không xác định",
                    Description = p.Description,
                    CreateAt = p.CreateAt
                });
            }
            return result;
        }

        public ProductViewModel GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return null;

            var category = _categories.FirstOrDefault(c => c.Id == product.CategoryID);
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.Image,
                Price = product.Price,
                SalePrice = product.SalePrice,
                CategoryName = category != null ? category.Name : "Không xác định",
                Description = product.Description,
                CreateAt = product.CreateAt
            };
        }

        public List<NqtCategory> GetAllCategories()
        {
            return _categories;
        }
    }
}